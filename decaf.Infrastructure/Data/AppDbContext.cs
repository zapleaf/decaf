﻿using decaf.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace decaf.Infrastructure.Data;

// Connection string set in AppSettings, called in Program.cs, and passed here via "options"
// Create a new migration
//    1.) Using Package manager Console
//    2.) "add-migration <name>" creates the Migrations folder and migration class
//    3.) "update-database" updates database

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) //: IdentityDbContext<ApplicationUser>(options)
{

    public required DbSet<Channel> Channels { get; set; }
    public required DbSet<Video> Videos { get; set; }
    public required DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Channel
        modelBuilder.Entity<Channel>()
            .HasIndex(c => c.YTId)
            .IsUnique();

        // Configure Video
        modelBuilder.Entity<Video>()
            .HasIndex(v => v.YTId)
            .IsUnique();

        // navigation setup for the Video-Channel relationship
        // Simplified relationship using just YTId
        modelBuilder.Entity<Video>()
            .HasOne(v => v.Channel)
            .WithMany(c => c.Videos)
            .HasForeignKey(v => v.YTChannelId)
            .HasPrincipalKey(c => c.YTId);

        // Configure many-to-many relationship between Channel and Category
        modelBuilder.Entity<Channel>()
            .HasMany(c => c.Categories)
            .WithMany(c => c.Channels);
    }
}
