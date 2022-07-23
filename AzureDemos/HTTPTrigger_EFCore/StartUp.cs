using DataAccessLayer.ToDo;
using DomainLayer.Prdct;
using DomainLayer.ToDo;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(EFCore_Demo.Startup))]

namespace EFCore_Demo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("SQLConnectionString");


            builder.Services.AddDbContext<DbContext>(config =>
            {
                config.UseSqlServer(connectionString);
            });

             builder.Services.AddDbContext<TodoContext>(
                 config =>
                            {
                                config.UseSqlServer(connectionString);
                            },
                ServiceLifetime.Scoped);

          
            builder.Services.AddScoped<IToDoRepository, SqlToDoRepository>();
            builder.Services.AddScoped<IToDoService, ToDoService>();

            //builder.Services.AddDbContext<TodoContext>(
            //    options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));

            //builder.Services.AddSingleton<IProductService, ProductService>();
            //builder.Services.AddDbContext<BooksContext>(config =>
            //{
            //    config.UseSqlServer(Environment.GetEnvironmentVariable("BooksConnection"));
            //});
        }
    }
}
