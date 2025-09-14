
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using NPO.WebApi.Data;
using Microsoft.IdentityModel.Tokens;

namespace NPO.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add DbContext with InMemory provider
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

        // Add JWT token authentication.
        var authDomain = builder.Configuration["Auth0:Domain"];
        var authAudience = builder.Configuration["Auth0:Audience"];

        if (string.IsNullOrEmpty(authDomain) || string.IsNullOrEmpty(authAudience))
        {
            // Testmodus: accepteer elk JWT
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = false,
                        ValidateLifetime = false
                    };
                });
        }
        else
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = authDomain;
                    options.Audience = authAudience;
                });
        }
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Seed the database
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var items = Data.Helpers.CameraItemCsvReader.Read("../NPO.WebApi.Data/camera_locations.csv");
            dbContext.Items.AddRange(items);
            dbContext.SaveChanges();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            IdentityModelEventSource.ShowPII = true;
            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }

        app.UseHttpsRedirection();

        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
