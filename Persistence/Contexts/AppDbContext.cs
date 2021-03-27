
using System;
using Microsoft.EntityFrameworkCore;
using RugbyUnion.API.Domain.Models;

namespace RugbyUnion.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Team>().HasKey(entity => entity.Id);
            builder.Entity<Team>().Property(entity => entity.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Team>().Property(entity => entity.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Team>().Property(entity => entity.Ground).IsRequired();
            builder.Entity<Team>().Property(entity => entity.Coach).IsRequired();
            builder.Entity<Team>().Property(entity => entity.FoundedYear).IsRequired();
            builder.Entity<Team>().Property(entity => entity.Region).IsRequired();
            builder.Entity<Team>().HasMany(entity => entity.Players).WithOne(entity => entity.Team).HasForeignKey(entity => entity.TeamId);

            builder.Entity<Team>().HasData(
                new Team { Id = 100, Name = "Sheep, stone", Ground = "Westridge", Coach = "Ilysa Papen", FoundedYear = 2009, Region = "Freiburg im Breisgau" },
                new Team { Id = 101, Name = "Wallaby, euro", Ground = "Tony", Coach = "Xavier Eskriet", FoundedYear = 1993, Region = "Taoyang" }
            );

            builder.Entity<Player>().HasKey(entity => entity.Id);
            builder.Entity<Player>().Property(entity => entity.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Player>().Property(entity => entity.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Player>().Property(entity => entity.DateOfBirth).IsRequired();
            builder.Entity<Player>().Property(entity => entity.Height).IsRequired();
            builder.Entity<Player>().Property(entity => entity.Weight).IsRequired();
            builder.Entity<Player>().Property(entity => entity.PlaceOfBirth).IsRequired();
        }
    }
}
