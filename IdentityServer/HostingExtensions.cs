using IdentityServer.Data;
using IdentityServer.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddControllers();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        // добавление сервисов аутентификации
        builder.IdentityConfigureServices();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.SwaggerConfigureServices();

        builder.Services.AddCors();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.SwaggerConfigurePipeline();
        }

        app.UseCors(builder => builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());

        app.UseHttpsRedirection();

        app.IdentityConfigurePipeline();

        app.MapControllers();

        return app;
    }
}
