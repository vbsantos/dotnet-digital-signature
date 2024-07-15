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
        // Configuração de um-para-muitos entre Envelope e Document
        modelBuilder.Entity<Envelope>()
            .HasMany(e => e.Documents)
            .WithOne(d => d.Envelope)
            .HasForeignKey(d => d.EnvelopeId);

        // Configuração de um-para-muitos entre Envelope e Signatory
        modelBuilder.Entity<Envelope>()
            .HasMany(e => e.Signatories)
            .WithOne(s => s.Envelope)
            .HasForeignKey(s => s.EnvelopeId);

        // Configuração de um-para-muitos entre Repository e Envelope
        modelBuilder.Entity<Repository>()
            .HasMany(r => r.Envelopes)
            .WithOne(e => e.Repository)
            .HasForeignKey(e => e.RepositoryId);

        // Configuração de um-para-muitos entre User e Repository
        // modelBuilder.Entity<User>()
        //     .HasMany(u => u.Repositories)
        //     .WithOne(r => r.Owner)
        //     .HasForeignKey(r => r.OwnerId);

        base.OnModelCreating(modelBuilder);
    }
}
