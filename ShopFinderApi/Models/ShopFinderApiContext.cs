using Microsoft.EntityFrameworkCore;

namespace ShopFinderApi.Models;

public class ShopFinderApiContext : DbContext
{
  public DbSet<Shop> Shops { get; set; }
  public DbSet<Restaurant> Restaurants { get; set; }
  public DbSet<User> Users { get; set;}

  public ShopFinderApiContext(DbContextOptions<ShopFinderApiContext> options) : base(options) { }

  //include seed data
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Shop>()
      .HasData(
        new Shop { ShopId = 1, Description = "Larry's Rock Climbing", Rating = 5 },
        new Shop { ShopId = 2, Description = "DogLand", Rating = 5 },
        new Shop { ShopId = 3, Description = "Paint-topia", Rating = 4 }
      );

    builder.Entity<Restaurant>()
    .HasData(
      new Restaurant { RestaurantId = 1, Description = "La Bella", Rating = 5, TypeOfFood = "Italian" },
      new Restaurant { RestaurantId = 2, Description = "CurryHouse", Rating = 4, TypeOfFood = "Indian" },
      new Restaurant { RestaurantId = 3, Description = "Ye Old Fish and Chip", Rating = 4, TypeOfFood = "English" }
    );

    builder.Entity<User>()
    .HasData(
      new User { UserId = 1, UserName = "sampleUser", Password = "samplePass" }
    );
  }
}

