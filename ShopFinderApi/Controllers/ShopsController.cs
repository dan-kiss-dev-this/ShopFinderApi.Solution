using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopFinderApi.Models;

namespace ShopFinderApi.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class ShopsController : ControllerBase
{
    private readonly ShopFinderApiContext _db;
    private readonly ILogger<ShopsController> _logger;

    public ShopsController(ShopFinderApiContext db, ILogger<ShopsController> logger)
    {
        _db = db;
        _logger = logger;
    }

    // see swagger docs or use postman to get localhost:5000/api/Shops
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shop>>> Get()
    {
        return await _db.Shops.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Shop>> GetShop(int id)
    {
        Shop shop = await _db.Shops.FindAsync(id);
        if (shop == null)
        {
            return NotFound();
        }
        return shop;
    }

    [HttpPost]
    public async Task<ActionResult> Post(Shop shop)
    {
        await _db.Shops.AddAsync(shop);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetShop), new { id = shop.ShopId }, shop);
    }
}
