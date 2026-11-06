using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Smallbiz.Web.Data;
using System.Security.Claims;
using Smallbiz.Domain.Entities;

namespace Smallbiz.Web.Services;

public class CurrentCompany(AuthenticationStateProvider authStateProvider, IDbContextFactory<ApplicationDbContext> dbFactory)
{
    private bool loaded;
    public string? UserId { get; private set; }
    public int? Id { get; private set; }
    public string? Name { get; private set; }
    public List<Company> MyCompanies { get; private set; } = [];

    public async Task LoadAsync()
    {
        if (loaded) return;
        loaded = true;

        var auth = await authStateProvider.GetAuthenticationStateAsync();
        UserId = auth.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (UserId is null) return;

        await using var db = await dbFactory.CreateDbContextAsync();
        MyCompanies = await db.CompanyUsers
            .Where(cu => cu.UserId == UserId)
            .Select(cu => cu.Company)
            .OrderBy(c => c.Name)
            .AsNoTracking()
            .ToListAsync();

        var user = await db.Users.FindAsync(UserId);
        var current = MyCompanies.FirstOrDefault(c => c.Id == user?.CurrentCompanyId)
                      ?? MyCompanies.FirstOrDefault();

        Id = current?.Id;
        Name = current?.Name;
    }

    public async Task SelectAsync(int companyId)
    {
        if (UserId is null) return;

        await using var db = await dbFactory.CreateDbContextAsync();
        bool hasAccess = await db.CompanyUsers.AnyAsync(cu => cu.CompanyId == companyId && cu.UserId == UserId);
        if (!hasAccess) return;

        var user = await db.Users.FindAsync(UserId);
        if (user is null) return;
        user.CurrentCompanyId = companyId;
        await db.SaveChangesAsync();
    }
}
