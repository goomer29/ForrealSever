using System.Text.Json.Serialization;
using ForrealServerBL;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using ForrealServerBL.Models;
using Microsoft.Identity.Client;

namespace ContactsSever
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            #region DBCONTEXT
            string connection = builder.Configuration.GetConnectionString("ForrealDB");
            builder.Services.AddDbContext<ForrealDBContext>(options => options.UseSqlServer(connection));
            #endregion
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}