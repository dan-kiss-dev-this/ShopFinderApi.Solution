using Microsoft.EntityFrameworkCore;

namespace ShopFinderApi.Models;

public class ShopFinderApiContext : DbContext
{
  public DbSet<Shop> Shops { get; set; }

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
  }
}
