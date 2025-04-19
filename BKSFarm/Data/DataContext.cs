using BKSFarm.api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BKSFarm.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Seed> Seeds { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Egg> Eggs { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserSeed> UserSeeds { get; set; }
		public DbSet<UserPlant> UserPlants { get; set; }
		public DbSet<UserEgg> UserEggs { get; set; }
		public DbSet<UserAnimal> UserAnimals { get; set; }
	}
}
