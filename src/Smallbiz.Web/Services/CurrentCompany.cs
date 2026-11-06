using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Smallbiz.Web.Data;

namespace Smallbiz.Web.Services;

public class CurrentCompany(AuthenticationStateProvider authStateProvider, IDbContextFactory<ApplicationDbContext> dbFactory)
{
    private bool loaded;
    public string? UserId { get; private set; }
    public int? Id { get; private set; }
    public string? Name { get; private set; }

    public async Task LoadAsync()
    {
        if(loaded) return;
        loaded = true;

        var auth = await authStateProvider.GetAuthenticationStateAsync();
        UserId = auth.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (UserId is null) return;

        await using var db = await dbFactory.CreateDbContextAsync();
        var company = await db.CompanyUsers
            .Where(cu => cu.UserId == UserId)
            .Select(cu => cu.Company)
            .OrderBy(c => c.Name)
            .FirstOrDefaultAsync();

        Id = company?.Id;
        Name = company?.Name;
    }
}
