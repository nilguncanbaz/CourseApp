﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
namespace CourseApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions{
                FileProvider= new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                    RequestPath="/modules"

            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // localhost:5000/course/list
            // localhost:5000/course/details/1
            // routing


            // localhost:5000/course/list
            // localhost:5000/course/details/5
            // app.UseMvcWithDefaultRoute();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "CoursesByReleased",
                    "courses/released/{year}/{month}",
                    new{ controller="Course", action="ByReleased"},
                    new{ year=@"\d{4}", month=@"\d{2}"}
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
