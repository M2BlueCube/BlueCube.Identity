using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueCube.Identity.Data;
public class BlueCubeIdentityDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public BlueCubeIdentityDbContext(DbContextOptions<BlueCubeIdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}