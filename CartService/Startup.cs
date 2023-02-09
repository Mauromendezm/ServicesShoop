using CartService.Aplication;
using CartService.Persistence;
using CartService.RemoteInterface;
using CartService.RemoteServices;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService
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
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddDbContext<CartContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("default"), ServerVersion.AutoDetect(Configuration.GetConnectionString("default")));

            });
            services.AddControllers();
            services.AddMediatR(typeof(New.Handler).Assembly);

            services.AddHttpClient("Books", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:BookService"]);
            });
            
            services.AddHttpClient("Autors", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:AutorService"]);
            });

            services.AddAutoMapper(typeof(Program));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
