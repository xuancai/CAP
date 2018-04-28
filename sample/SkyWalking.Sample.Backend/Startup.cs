﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkyWalking.AspNetCore;
using SkyWalking.Diagnostics.CAP;

namespace SkyWalking.Sample.Backend
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
            services.AddMvc();

            //services.AddCap(x =>
            //{
            //    x.UseKafka("192.168.10.110:9092");
            //    x.UseMySql("Server=192.168.10.110;Database=testcap;UserId=root;Password=123123;");
            //});

            services.AddSkyWalking(option =>
            {
                option.DirectServers = "localhost:11800";
                option.ApplicationCode = "asp-net-core-backend";
            });//.AddCap();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

           // app.UseCap();
        }
    }
}