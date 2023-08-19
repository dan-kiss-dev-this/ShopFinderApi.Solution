using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ShopFinderApi.Models;

namespace ShopFinderApi.Controllers;

[ApiController]
[Route("api/[controller]/")]
[Authorize]
public class RestaurantsController : ControllerBase
{
    private readonly ShopFinderApiContext _db;
    private readonly ILogger<RestaurantsController> _logger;

    public RestaurantsController(ShopFinderApiContext db, ILogger<RestaurantsController> logger)
    {
        _db = db;
        _logger = logger;
    }

    // see swagger docs or use postman to get localhost:5000/api/Restaurants
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Restaurant>>> Get()
    {
        return await _db.Restaurants.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
    {
        Restaurant restaurant = await _db.Restaurants.FindAsync(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        return restaurant;
    }

    [HttpPost]
    public async Task<ActionResult> Post(Restaurant restaurant)
    {
        await _db.Restaurants.AddAsync(restaurant);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.RestaurantId }, restaurant);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Restaurant>> Put(int id, Restaurant restaurant)
    {
        if (id != restaurant.RestaurantId)
        {
            return BadRequest();
        }
        // the async part is not the update but the save
        _db.Restaurants.Update(restaurant);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RestaurantExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        //204 code in empty object shows success
        return NoContent();
    }

    private bool RestaurantExists(int id)
    {
        return _db.Restaurants.Any(e => e.RestaurantId == id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
    {
        Restaurant deleteRestaurant = await _db.Restaurants.FindAsync(id);
        if (deleteRestaurant == null)
        {
            return NotFound();
        }
        _db.Restaurants.Remove(deleteRestaurant);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
