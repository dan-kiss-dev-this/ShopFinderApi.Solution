using System.ComponentModel.DataAnnotations;
using ShopFinderApi.Models;

namespace ShopFinderApi.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    [Required]
    public string Description { get; set; }
    public int Rating { get; set; }
    public string TypeOfFood { get; set; }
  }
}