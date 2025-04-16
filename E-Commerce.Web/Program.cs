
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace E_Commerce.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Add services to the container

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); // for swagger documentation
            builder.Services.AddSwaggerGen();           // for swagger documentation

            builder.Services.AddDbContext<StoreDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion
            var app = builder.Build();

            #region Configure the HTTP request pipeline

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
