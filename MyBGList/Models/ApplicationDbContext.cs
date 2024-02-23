using Microsoft.EntityFrameworkCore;

namespace MyBGList.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BoardGamesDomains>()
            .HasKey(i => new { i.BoardGameId, i.DomainId });

        modelBuilder.Entity<BoardGamesDomains>()
            .HasOne(x => x.BoardGame)
            .WithMany(y => y.BoardGamesDomains)
            .HasForeignKey(f => f.BoardGameId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGamesDomains>()
            .HasOne(o => o.Domain)
            .WithMany(m => m.BoardGamesDomains)
            .HasForeignKey(f => f.DomainId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGamesMechanics>()
            .HasKey(i => new { i.BoardGameId, i.MechanicId });

        modelBuilder.Entity<BoardGamesMechanics>()
            .HasOne(x => x.BoardGame)
            .WithMany(y => y.BoardGamesMechanics)
            .HasForeignKey(f => f.BoardGameId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGamesMechanics>()
            .HasOne(o => o.Mechanic)
            .WithMany(m => m.BoardGamesMechanics)
            .HasForeignKey(f => f.MechanicId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
    
    public DbSet<BoardGame> BoardGames => Set<BoardGame>();
    public DbSet<Domain> Domains => Set<Domain>();
    public DbSet<Mechanic> Mechanics => Set<Mechanic>();
    public DbSet<BoardGamesDomains> BoardGamesDomains 
        => Set<BoardGamesDomains>();
    public DbSet<BoardGamesMechanics> BoardGamesMechanics => Set<BoardGamesMechanics>();
    
    
}