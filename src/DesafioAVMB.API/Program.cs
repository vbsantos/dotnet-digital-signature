using DesafioAVMB.Application;
using DesafioAVMB.Infrastructure;
using DesafioAVMB.Infrastructure.Persistence;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
    });

    builder.Configuration
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio AVMB", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement{
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    });

    builder.Services
        .AddEndpointsApiExplorer()
        .AddProblemDetails()
        .AddHttpClient()
        .AddControllers();

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseCors("AllowAllOrigins");
    // Apply migrations
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DisplayRequestDuration();
    });

    app.UseHttpsRedirection();
    app.UseExceptionHandler();
    app.UseAuthorization();

    // Identity Endpoints
    app.MapGroup("api/account")
        .WithOpenApi()
        .WithDescription("Only the basic endpoints (/login, /register) work for now.")
        .MapIdentityApi<IdentityUser>()
        .WithSummary("Microsoft Identity Endpoint")
        .WithTags("Account");

    app.MapControllers();

    app.Run();
}
