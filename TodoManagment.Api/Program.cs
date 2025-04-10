using Microsoft.EntityFrameworkCore;
using TodoManagment.Infrastructure;
using TodoManagment.Infrastructure.Extensions;
using TodoManagment.Core.Extensions;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TodoManagment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true; // Adds API version headers in responses
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Versioning via URL segment
                //options.ApiVersionReader = new QueryStringApiVersionReader("api-version"); // Versioning via query string
                //options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddCoreServices();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            app.UseHsts();

            // Apply any pending migrations at startup
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<Context>();
                    context.Database.Migrate(); // Apply pending migrations
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while applying migrations.");
                }
            }

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
