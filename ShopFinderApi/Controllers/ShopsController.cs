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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shop>>> Get()
    {
        return await _db.Shops.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Shop>> Get(int id)
    {
        Shop shop = await _db.Shops.FindAsync(id);
        if (shop == null)
        {
            return NotFound();
        }
        return shop;
    }
}
