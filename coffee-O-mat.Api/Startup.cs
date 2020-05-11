using System;
using System.IO;
using coffee_O_mat.Data.Contracts;
using coffee_O_mat.Data.Repositories;
using com.b_velop.coffee_O_mat.Api.Middlewares;
using com.b_velop.coffee_O_mat.Application.Brew;
using com.b_velop.coffee_O_mat.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace com.b_velop.coffee_O_mat.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(List).Assembly);
            services.AddScoped<ICoffeeOMatRepository, CoffeeOMatRepository>();
            
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            var pw = string.Empty;
            var fileInfo = new FileInfo(password);
            if (fileInfo.Exists)
            {
                using var stream = fileInfo.OpenRead();
                using var streamReader = new StreamReader(stream);
                pw =  streamReader.ReadToEnd();
            }
            var username = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");

            var connection = $"Host={host};Port=5432;Username={username};Password={pw};Database=coffeeOmat;";
            
            services.AddDbContext<CoffeeContext>(options =>
            {
                options.UseNpgsql(connection);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseErrorHandlingMiddleware();
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello Coffee!"); });
            });
        }
    }
}