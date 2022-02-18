using MenuDeRestaurants.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuDeRestaurants.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<DishModel> Dish { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RestaurantModel>().HasKey(x => x.Id);

            modelBuilder.Entity<DishModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DishModel>().HasKey(x => x.Id);

            modelBuilder.Entity<RestaurantModel>()
                .HasOne(x => x.Dish)
                .WithOne(x => x.Restaurant)
                .HasForeignKey<DishModel>(x => x.RestaurantId);
        }
    }
}
