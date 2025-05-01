using DomainLayer.Exceptions;
using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace E_Commerce.Web.CustomMiddleWares
{
    public class CustomExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionHandlerMiddleWare> logger;

        public CustomExceptionHandlerMiddleWare(RequestDelegate next,ILogger<CustomExceptionHandlerMiddleWare> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
                await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Something went wrong");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            // set status code for Response
            //httpContext.Response.StatusCode = 500;
            //httpContext.Response.StatusCode=(int) HttpStatusCode.InternalServerError;
            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            // set Content Type For Response
            //httpContext.Response.ContentType = "application/json";

            // Response object
            var Response = new ErrorToReturn
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message
            };

            // return object as json
            //var ResponseToReturn=JsonSerializer.Serialize(Response);
            //await httpContext.Response.WriteAsync(ResponseToReturn);

            await httpContext.Response.WriteAsJsonAsync(Response); // this make ContentType = "application/json"
                                                                   // make json serialization and write async
        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var Response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"EndPoint => {httpContext.Request.Path} is not found"
                };
                await httpContext.Response.WriteAsJsonAsync(Response);
            }
        }
    }
}
