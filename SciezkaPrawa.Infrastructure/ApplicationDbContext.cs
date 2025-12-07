using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SciezkaPrawa.Domain.Entities;

namespace SciezkaPrawa.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }  
    internal DbSet<Act> Acts { get; set; }
    internal DbSet<ActStage> ActStages { get; set; }
    internal DbSet<ActVersion> ActVersion { get; set; }
    internal DbSet<ActReadingVote> ActReadingVotes { get; set; }
    internal DbSet<Tag> Tags { get; set; }
    internal DbSet<ActTag> ActTags { get; set; }
    public DbSet<ActComment> ActComments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ActTag>()
            .HasKey(at => new { at.ActId, at.TagId });

        modelBuilder.Entity<ActTag>()
            .HasOne(at => at.Act)
            .WithMany(a => a.Tags)
            .HasForeignKey(at => at.ActId);

        modelBuilder.Entity<ActTag>()
            .HasOne(at => at.Tag)
            .WithMany(t => t.ActTags)
            .HasForeignKey(at => at.TagId);

        modelBuilder.Entity<ActStage>()
            .HasOne(s => s.Act)
            .WithMany(a => a.Stages)
            .HasForeignKey(s => s.ActId);

        modelBuilder.Entity<ActVersion>()
            .HasOne(v => v.Act)
            .WithMany(a => a.Versions)
            .HasForeignKey(v => v.ActId);

        modelBuilder.Entity<ActReadingVote>()
            .HasOne(rv => rv.Act)
            .WithMany(a => a.ReadingVotes)
            .HasForeignKey(rv => rv.ActId);

        modelBuilder.Entity<ActComment>()
               .HasOne(c => c.Act)
               .WithMany(a => a.Comments)
               .HasForeignKey(c => c.ActId)
               .OnDelete(DeleteBehavior.Cascade);

    }

}




