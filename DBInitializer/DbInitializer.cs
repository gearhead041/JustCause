using JustCause.Data;
using JustCause.DbInitializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JustCause.Services;
public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext context;
    private readonly UserManager<IdentityUser> userManager;

    public DbInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        this.context = context;
        this.userManager = userManager;
    }
    public void Initialize()
    {
        try
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        catch (Exception)
        {
            throw;
            //TODO log exceptions
        }

        userManager.CreateAsync(new IdentityUser
        {
            UserName = "admin@justcause.com",
            Email = "admin@justcause.com",
        }, "Admin.041").GetAwaiter().GetResult();
    }
}
