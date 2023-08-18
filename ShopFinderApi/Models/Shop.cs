using System.ComponentModel.DataAnnotations;

namespace ShopFinderApi.Models
{
  public class Shop
  {
    public int ShopId { get; set; }
    [Required]
    public string Description { get; set; }
    public int Rating { get; set; }
  }
}