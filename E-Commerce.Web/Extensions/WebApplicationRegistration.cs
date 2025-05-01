using DomainLayer.Contracts;
using E_Commerce.Web.CustomMiddleWares;

namespace E_Commerce.Web.Extensions
{
    public static class WebApplicationRegistration
    {
        public static async Task SeedDataBaseAsync(this WebApplication app)
        {
            var Scoope = app.Services.CreateScope();

            var DataSeedingObj = Scoope.ServiceProvider.GetRequiredService<IDataSeeding>();

            await DataSeedingObj.DataSeedAsync();
        }

        public static IApplicationBuilder UseCustomExceptionsMiddleWares(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleWare>();
            return app;
        }

    }
}
