using ali.models;
using Microsoft.EntityFrameworkCore;

namespace ali.data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasCollation("case_insensitive", locale: "en-u-ks-primary", provider: "icu", deterministic: false);

        modelBuilder.UseDefaultColumnCollation("case_insensitive");

        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("id");
        modelBuilder.Entity<User>().Property(u => u.Role).HasColumnName("role");
        modelBuilder.Entity<User>().Property(p => p.PasswordHash).HasColumnName("password_hash");
        modelBuilder.Entity<User>().Property(p => p.PasswordSalt).HasColumnName("password_salt");
        modelBuilder.Entity<User>().Property(u => u.Username).HasColumnName("username");
        modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email");
    }
}