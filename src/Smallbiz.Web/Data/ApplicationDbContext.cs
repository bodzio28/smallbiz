using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smallbiz.Domain.Entities;
using Smallbiz.Web.Services;
namespace Smallbiz.Web.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Contractor> Contractors => Set<Contractor>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<CompanyUser> CompanyUsers => Set<CompanyUser>();

    public int? CurrentCompanyId { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); //Konfiguruje tabele Identity
        builder.Entity<Contractor>().HasIndex(c => new { c.CompanyId, c.Code }).IsUnique();
        builder.Entity<Contractor>().HasQueryFilter(c => c.CompanyId == CurrentCompanyId);
        builder.Entity<CompanyUser>().HasKey(cu => new { cu.CompanyId, cu.UserId });
        builder.Entity<CompanyUser>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(cu => cu.UserId);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<Contractor>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CompanyId = CurrentCompanyId
                    ?? throw new InvalidOperationException("Nie wybrano firmy.");
            }
            else if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
            {
                if (entry.Entity.CompanyId != CurrentCompanyId)
                {
                    throw new InvalidOperationException("Kontrahent należy do innej firmy.");
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

