using ITLOOP_HFT_2021221.Logic;
using ITLOOP_HFT_2021221.Data;
using ITLOOP_HFT_2021221.Repository;
using ITLOOP_HFT_2021221.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace ITLOOP_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddTransient<ICarLogic<Car>, CarLogic>();
            services.AddTransient<ICarRepository<Car>, CarRepository>();

            services.AddTransient<ICarStoreLogic<CarStore>, CarStoreLogic>();
            services.AddTransient<ICarStoreRepository<CarStore>, CarStoreRepository>();

            services.AddTransient<IRentingLogic<Renting>, RentingLogic>();
            services.AddTransient<IRentingRepository<Renting>, RentingRepository>();

            services.AddSingleton<AppDbContext, AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
