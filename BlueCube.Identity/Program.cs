using BlueCube.Identity.Services;
using BlueCube.Identity.Services.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new KeyNotFoundException(" DefaultConnection is not found in Configuration");

services.AddDbContext<IdentityDbContext>(options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("BlueCube.Identity")));

services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IIdentityService), typeof(IdentityService));

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