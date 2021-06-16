using ChatboxApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Middleware
{
    public class CreateSession
    {
        private readonly RequestDelegate _next;

        public CreateSession(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext, HttpRequest httpRequest)
        {
            UserModel user = new UserModel();
            
        }

      /*  public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }*/
    }
}
