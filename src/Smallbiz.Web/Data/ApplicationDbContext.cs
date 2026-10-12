using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smallbiz.Domain.Entities;
namespace Smallbiz.Web.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Contractor> Contractors => Set<Contractor>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); //Konfiguruje tabele Identity
        builder.Entity<Contractor>().HasIndex(c => c.Code).IsUnique();
    }
}

