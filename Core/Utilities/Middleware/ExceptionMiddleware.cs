
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace pdksApi.Core.Utilities.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                //await HandleExceptionAsync(httpContext, e);
            }
        }

        //private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        //{
        //    httpContext.Response.ContentType = "application/json";
        //    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //    var message = "Internal Server Error";
        //    if (e.GetType() == typeof(ValidationException))
        //    {
        //        message = e.Message;
        //    }else if (e.GetType() == typeof(Exception))
        //    {
        //        message = e.Message;
        //        httpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
        //    }
        //    else
        //    {
        //        message = "Something went wrong. Please try again.";
        //    }
        //    return httpContext.Response.WriteAsync(new ErrorDetail
        //    {
        //        StatusCode = httpContext.Response.StatusCode,
        //        Message = message
        //    }.ToString());

        //}
    }
}
