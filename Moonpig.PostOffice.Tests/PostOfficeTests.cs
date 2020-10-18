namespace Moonpig.PostOffice.Tests
{
    using System;
    using System.Collections.Generic;
    using Api.Controllers;
    using Moonpig.PostOffice.Data;
    using Moonpig.PostOffice.Service;
    using Moq;
    using Shouldly;
    using Xunit;

    public class PostOfficeTests
    {
        DespatchController Controller;
        Mock<IDespatchManagement> despatchManagement;
        Mock<IDbContext> dbContext;
        public PostOfficeTests()
        {
            dbContext = new Mock<IDbContext>();
            despatchManagement = new Mock<IDespatchManagement>();
            Controller = new DespatchController(despatchManagement.Object);
            despatchManagement.Setup(c => c.CalculateDespatch(It.IsAny<List<int>>(), It.IsAny<DateTime>())).Returns(DateTime.Now);
        }
        [Fact]
        public void OneProductWithLeadTimeOfOneDay()
        {
            var date = Controller.GetDate(new List<int>() {1}, DateTime.Now);
            date.Date.Date.ShouldBe(DateTime.Now.Date);
        }


    }
}
