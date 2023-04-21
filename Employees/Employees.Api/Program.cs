
using Employees.Api.Filters;
using Employees.Application;
using Employees.Domain.Shared;
using Employees.Infrastructure;
using Employees.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Employees.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ConfigurationManager configuration = builder.Configuration;
            builder.Services.RegisterInfrastrucutreModule(configuration);
            builder.Services.RegisterApplicationModule();

            builder.Services.AddScoped<NotificationContext>();
            builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());

            //builder.Services.AddControllers(config =>
            //{
            //    config.Filters.Add<NotificationFilter>();
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}