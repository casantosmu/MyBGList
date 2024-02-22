using Microsoft.EntityFrameworkCore;

namespace MyBGList.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BoardGamesDomains>()
            .HasKey(i => new { i.BoardGameId, i.DomainId });

        modelBuilder.Entity<BoardGamesMechanics>()
            .HasKey(i => new { i.BoardGameId, i.MechanicId });
    }
}