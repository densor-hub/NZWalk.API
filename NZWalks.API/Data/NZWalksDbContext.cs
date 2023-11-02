using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seeding Data into Difficulties Table
            var listOfDifficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("c98811c2-8a75-4f21-9456-6631c26586c2"),
                    Name="Easy",
                },
                new Difficulty()
                {
                    Id=Guid.Parse("59b2d3a9-58c5-4097-8cd4-6ba2d3ec854a"),
                    Name="Medium",
                },
                new Difficulty()
                {
                    Id=Guid.Parse("40fc60ab-745b-41ca-911e-f448d26aed2b"),
                    Name="Hard",
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(listOfDifficulties);

            //seeding Data into Regions Tabel
            var listOfRegions = new List<Region>()
            {
                new Region()
                {
                    Id= Guid.Parse("c4da9f85-b783-41bc-995f-2f365c57fa13"),
                    Name="Western Region",
                    Code="W/R",
                    RegionImageUrl="https://...anyyyy"
                },
                new Region()
                {
                    Id= Guid.Parse("ac9b24ef-2612-4f74-a543-2acd3720a04c"),
                    Name="Ashanti Region",
                    Code="A/R",
                    RegionImageUrl="https://...anyyyy"
                },
                new Region()
                {
                    Id= Guid.Parse("403ad540-e02a-4f58-b9ad-e0da81aa47cb"),
                    Name="Central Region",
                    Code="C/R",
                    RegionImageUrl="https://...anyyyy"
                },
                new Region()
                {
                    Id= Guid.Parse("30ff8627-7e90-49c5-bd46-428164fee121"),
                    Name="Western Region",
                    Code="W/R",
                    RegionImageUrl="https://...anyyyy"
                },
                new Region()
                {
                    Id= Guid.Parse("2cccdcad-19a4-4195-a2d6-3defdf1aad5e"),
                    Name="Ashanti Region",
                    Code="A/R",
                    RegionImageUrl="https://...anyyyy"
                },
                new Region()
                {
                    Id= Guid.Parse("8a1cf8a6-eb83-4405-92f6-79308ba91497"),
                    Name="Central Region",
                    Code="C/R",
                    RegionImageUrl="https://...anyyyy"
                }
            };

            modelBuilder.Entity<Region>().HasData(listOfRegions);
        }
    }



}
