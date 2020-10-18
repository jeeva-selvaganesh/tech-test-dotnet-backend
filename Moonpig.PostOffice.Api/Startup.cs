namespace Moonpig.PostOffice.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Moonpig.PostOffice.Data;
    using Moonpig.PostOffice.Service;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IDbContext>(new DbContext());
            services.AddSingleton<ISupplierService>((sp) => new SupplierService(sp.GetRequiredService<IDbContext>()));
            services.AddSingleton<IProductService>((sp) => new ProductService(sp.GetRequiredService<IDbContext>()));
            services.AddSingleton<IDespatchManagement>((sp)=>  new DespatchManagement(sp.GetRequiredService<IDbContext>(), sp.GetRequiredService<ISupplierService>(), sp.GetRequiredService<IProductService>()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
