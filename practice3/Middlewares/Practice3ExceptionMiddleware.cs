using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using System.Net;
using Newtonsoft.Json;
using Logic.Managers;

namespace practice3.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Practice3ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public Practice3ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                Console.WriteLine("Antes del NEXT, en Exception handler middleware");
                await _next(httpContext);
                Console.WriteLine("Antes del NEXT, en Exception handler middleware");
            }
            catch(Exception e)
            {
                await HandleExceptionAsync(e, httpContext);
            }
        }

        private Task HandleExceptionAsync(Exception e, HttpContext httpContext)
        {
            string errorMessage = "";
            int errorCode = (int)HttpStatusCode.OK;
            if(e.InnerException is PartnerServiceException)
            {
                errorMessage = "Something happens on our Services out of our system " + e.Message;
                errorCode = (int)HttpStatusCode.NotFound;
            }
            if (e is InvalidCampaignDataException)
            {
                errorMessage = "Data validation: " + e.Message;
                errorCode = (int)HttpStatusCode.OK;
            }
            var response = new { message = errorMessage, errorCode = errorCode };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = errorCode;
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Practice3ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UsePractice3ExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Practice3ExceptionMiddleware>();
        }
    }
}
