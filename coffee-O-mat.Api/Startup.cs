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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(List).Assembly);
            services.AddScoped<ICoffeeOMatRepository, CoffeeOMatRepository>();
            services.AddDbContext<CoffeeContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("default"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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