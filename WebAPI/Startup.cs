using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
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
            //**** Autofac **** Hemp IOC(instance yönetimi) Container hemde AOP(log iþlmeleri) sunar bunu kullanýcaz
            //Autofac, Ninject, CastleWindsor, StructureMap, LightInject, DryInject -->IoC Container sunan bazý platformlar
           
            services.AddControllers();
            //IoC burda  (içinde data tutmuyorsa kullan)
            services.AddSingleton<IProductService,ProductManager>();//bizim yerimize olusturdugu tek ýnsatance yý verýyor
            //singleton : biri ctor da Iproduct service isterse Product manager ver demek ama 1 kere olusturup hep onu verýr
            services.AddSingleton<IProductDal, EfProductDal>(); //Product manager bunlara bagýmlý dýye bunlarýda verdýk
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
