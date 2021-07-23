using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ChatboxApi.ApplicationCore.Common;
using ChatboxApi.ApplicationCore.Services;
using ChatboxApi.ApplicationCore.Common.Interfaces;
using ChatboxApi.Infrastructure.ClientApi;
using ChatboxApi.Infrastructure.Services;

namespace ChatboxApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient<IConnectyCubeApi, ConnectyCubeApi>(client =>
            {
                client.BaseAddress = new Uri("https://api.connectycube.com");

            });
            services.AddHttpClient<IConnectyCubeChatApi, ConnectyCubeChatApi>(client =>
            {
                client.BaseAddress = new Uri("https://api.connectycube.com");

            });
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
