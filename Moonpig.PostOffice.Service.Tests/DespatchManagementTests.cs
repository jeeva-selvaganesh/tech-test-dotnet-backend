using System;
using System.Collections.Generic;
using Moonpig.PostOffice.Data;
using Moonpig.PostOffice.Service;
using Moq;
using Shouldly;
using Xunit;

namespace Moonpig.PostOffice.Service.Tests
{
    public class DespatchManagementTests
    {
        Mock<IDbContext> _dbContext;
        Mock<IProductService> _iProductMock;
        Mock<ISupplierService> _iSupplierMock;
        IDespatchManagement despatchManagement;

        public DespatchManagementTests()
        {
            _dbContext = new Mock<IDbContext>();
            _iProductMock = new Mock<IProductService>();
            _iSupplierMock = new Mock<ISupplierService>();
            _iSupplierMock.Setup(c => c.GetSupplierID(It.IsAny<int>())).Returns(1);
            despatchManagement = new DespatchManagement(_dbContext.Object, _iSupplierMock.Object, _iProductMock.Object);
        }
        [Fact]
        public void OneProductWithLeadTimeOfOneDay()
        {
            _iProductMock.Setup(c => c.GetLeadDays(It.IsAny<int>())).Returns(1);
            var date = despatchManagement.CalculateDespatch(new List<int>() { 1 }, DateTime.Now);
            date.Date.Date.ShouldBe(DateTime.Now.Date.AddDays(1));
        }

        [Fact]
        public void OneProductWithLeadTimeOfTwoDay()
        {
            _iProductMock.Setup(c => c.GetLeadDays(It.IsAny<int>())).Returns(2);
            var date = despatchManagement.CalculateDespatch(new List<int>() { 2 }, DateTime.Now);
            date.Date.Date.ShouldBe(DateTime.Now.Date.AddDays(2));
        }

        [Fact]
        public void OneProductWithLeadTimeOfThreeDay()
        {
            _iProductMock.Setup(c => c.GetLeadDays(It.IsAny<int>())).Returns(3);
            var date = despatchManagement.CalculateDespatch(new List<int>() { 3 }, DateTime.Now);
            date.Date.Date.ShouldBe(DateTime.Now.Date.AddDays(3));
        }

        [Fact]
        public void SaturdayHasExtraTwoDays()
        {
            _iProductMock.Setup(c => c.GetLeadDays(It.IsAny<int>())).Returns(1);
            var date = despatchManagement.CalculateDespatch(new List<int>() { 1 }, new DateTime(2018, 1, 26));
            date.Date.ShouldBe(new DateTime(2018, 1, 26).Date.AddDays(3));
        }

        [Fact]
        public void SundayHasExtraDay()
        {
            _iProductMock.Setup(c => c.GetLeadDays(It.IsAny<int>())).Returns(3);
            var date = despatchManagement.CalculateDespatch(new List<int>() { 3 }, new DateTime(2018, 1, 25));
            date.Date.ShouldBe(new DateTime(2018, 1, 25).Date.AddDays(4));
        }
    }
}