using DesafioAVMB.Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioAVMB.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Document> Documents { get; set; }
    public DbSet<Envelope> Envelopes { get; set; }
    public DbSet<Repository> Repositories { get; set; }
    public DbSet<Signatory> Signatories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Document>()
            .HasOne(d => d.Envelope)
            .WithMany(e => e.Documents)
            .HasForeignKey(d => d.EnvelopeId);

        modelBuilder.Entity<Envelope>()
            .HasOne(e => e.Repository)
            .WithMany(r => r.Envelopes)
            .HasForeignKey(e => e.RepositoryId);

        modelBuilder.Entity<Repository>()
            .HasMany(r => r.Envelopes)
            .WithOne(e => e.Repository)
            .HasForeignKey(e => e.RepositoryId);

        modelBuilder.Entity<Signatory>()
            .HasMany(s => s.Documents)
            .WithOne();
    }
}
