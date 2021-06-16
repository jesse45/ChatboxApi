using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatboxApi.Middleware;
using ChatboxApi.Services.AuthService;
using ChatboxApi.Utilities.ConnectyCubeApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ChatboxApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatboxApi", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddHttpClient< IConnectyCubeApi, ConnectyCubeApi>(client =>
            {
                client.BaseAddress = new Uri("https://api.connectycube.com");

            });
            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatboxApi v1"));
            }

            app.UseHttpsRedirection();
            
            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            /*app.Map("/api/signup", context => context.UseMiddleware<CreateSession>())*/;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
