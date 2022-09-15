using JustCause.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JustCause.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<StudentRegistrationInfo>()
                .HasIndex(s => s.MatricNumber)
                .IsUnique();
        builder.Entity<Practical>()
                .HasIndex(p => p.Name)
                .IsUnique();
    }
    public DbSet<StudentRegistrationInfo>? StudentRegistrations { get; set; }
    public DbSet<Practical>? Practicals { get; set; }
}