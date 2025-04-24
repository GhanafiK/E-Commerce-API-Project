using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer(); // for swagger documentation
            Services.AddSwaggerGen();           // for swagger documentation

            return Services;
        }

        public static IServiceCollection AddWebApplicationServices(this IServiceCollection Services)
        {
             Services.Configure<ApiBehaviorOptions>(options =>
                 options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorsResponse
             );

            return Services;
        }
    }
}
