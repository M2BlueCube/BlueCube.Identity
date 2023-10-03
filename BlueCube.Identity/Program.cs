using BlueCube.Identity.Data;
using BlueCube.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new KeyNotFoundException(" DefaultConnection is not found in Configuration");

services.AddDbContext<BlueCubeIdentityDbContext>(options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("BlueCube.Identity")));

services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<BlueCubeIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IRsaService, RsaService>();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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