using Microsoft.EntityFrameworkCore;
using NZWalksApi.Models.Domain;

namespace NZWalksApi.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data for Difficulties
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>
            {
                new Difficulty()
                {
                    Id = Guid.Parse("db83be6c-21a8-459f-8db1-0632a126160a"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("fb2f8bc4-9fef-4d24-b963-625490915c20"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("3d581918-fddf-40b6-bd4c-410dd7699ff3"),
                    Name = "Hard"
                },
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("7dded8b0-f188-427c-b25d-071a937dffce"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://media.istockphoto.com/id/1060826424/photo/2018-jan-3-auckland-new-zealand-panorama-view-beautiful-landcape-of-the-building-in-auckland.jpg?s=612x612&w=0&k=20&c=lIMlIiLOflkMlKLzSkvAh0qsRKGLT4t4_N288A9Bq18="

                },
                new Region
                {
                    Id = Guid.Parse("ad86e1a3-9119-45e6-9574-d6f63730ff0a"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("d4dbd699-cc81-4e69-9d59-1db66f394a35"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                }
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
