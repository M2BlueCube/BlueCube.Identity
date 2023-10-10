using System.Text;
using BlueCube.Identity.Data;
using BlueCube.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LiteChat.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

// Add services to the container.

var connectionString = config.GetConnectionString("IdentityConnection") 
                       ?? throw new KeyNotFoundException(" IdentityConnection is not found in Configuration");

var jwtKey = Encoding.UTF8.GetBytes(config["Jwt:Key"] 
                                    ?? throw new KeyNotFoundException("Jwt secret key is null"));

services.AddDbContext<BlueCubeIdentityDbContext>(options =>
    options.UseNpgsql(connectionString, b => 
        b.MigrationsAssembly("BlueCube.Identity")));

services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<BlueCubeIdentityDbContext>()
    .AddDefaultTokenProviders();

services.AddScoped<IIdentityService, IdentityService>();
services.AddHostedService<MigrationService>();
services.AddScoped<IRsaService, RsaService>();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

services.AddSwaggerGen();

builder.Host.AddOrleansHost();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();