using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smallbiz.Domain.Entities;
namespace Smallbiz.Web.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Contractor> Contractors => Set<Contractor>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<CompanyUser> CompanyUsers => Set<CompanyUser>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); //Konfiguruje tabele Identity
        builder.Entity<Contractor>().HasIndex(c => c.Code).IsUnique();
        builder.Entity<CompanyUser>().HasKey(cu => new { cu.CompanyId, cu.UserId });
        builder.Entity<CompanyUser>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(cu => cu.UserId);

    }
}

