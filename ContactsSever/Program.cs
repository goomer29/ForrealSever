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
            builder.Services.AddDbContext<ForrealDbContext>(options => options.UseSqlServer(connection));
            #endregion
            #region 1- Json handling
            //json handling
            builder.Services.AddControllers().AddJsonOptions(o=>o.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.Preserve);
            #endregion
            #region 2- Session Support
            //Add Session support
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout=TimeSpan.FromMinutes(180);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            #endregion
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
            #region Use Files and Session
            //use files
            app.UseStaticFiles();
            app.UseRouting();
            #region Use Session
            app.UseSession();
            #endregion
            #endregion
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            //z9h9vqg0-7160.euw.devtunnels.ms/swagger/index.html
            //qskdd82d-7160.euw.devtunnels.ms/swagger/index.html
        }
    }
}