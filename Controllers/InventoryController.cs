using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pwa_api.Data;
using pwa_api.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace pwa_api.Controllers;

public class InventoryItem
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
}

[ApiController]
[Route("api/v1/inventories")]
public class InventoryController : ControllerBase
{
    private readonly InventoryDbContext _context;

    public InventoryController(InventoryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<InventoryItem>> GetInventories()
    {
        var inventories = new List<InventoryItem>
        {
            new InventoryItem { Name = "Wireless123 Headphones", Price = 89.99m, PictureUrl = "https://picsum.photos/seed/headphones/400/400" },
            new InventoryItem { Name = "Smart Watch Aof", Price = 249.99m, PictureUrl = "https://picsum.photos/seed/smartwatch/400/400" },
            new InventoryItem { Name = "Laptop Stand", Price = 45.50m, PictureUrl = "https://picsum.photos/seed/laptopstand/400/400" },
            new InventoryItem { Name = "Mechanical Keyboard", Price = 129.99m, PictureUrl = "https://picsum.photos/seed/keyboard/400/400" },
            new InventoryItem { Name = "USB-C Hub", Price = 34.99m, PictureUrl = "https://picsum.photos/seed/usbhub/400/400" },
            new InventoryItem { Name = "Wireless Mouse", Price = 29.99m, PictureUrl = "https://picsum.photos/seed/mouse/400/400" },
            new InventoryItem { Name = "4K Monitor", Price = 399.99m, PictureUrl = "https://picsum.photos/seed/monitor/400/400" },
            new InventoryItem { Name = "Desk Lamp", Price = 39.99m, PictureUrl = "https://picsum.photos/seed/desklamp/400/400" },
            new InventoryItem { Name = "Ergonomic Chair", Price = 299.99m, PictureUrl = "https://picsum.photos/seed/chair/400/400" },
            new InventoryItem { Name = "Webcam HD", Price = 79.99m, PictureUrl = "https://picsum.photos/seed/webcam/400/400" },
            new InventoryItem { Name = "Phone Stand", Price = 19.99m, PictureUrl = "https://picsum.photos/seed/phonestand/400/400" },
            new InventoryItem { Name = "Bluetooth Speaker", Price = 59.99m, PictureUrl = "https://picsum.photos/seed/speaker/400/400" },
            new InventoryItem { Name = "External SSD 1TB", Price = 149.99m, PictureUrl = "https://picsum.photos/seed/ssd/400/400" },
            new InventoryItem { Name = "Graphics Tablet", Price = 199.99m, PictureUrl = "https://picsum.photos/seed/tablet/400/400" },
            new InventoryItem { Name = "Cable Organizer", Price = 12.99m, PictureUrl = "https://picsum.photos/seed/organizer/400/400" },
            new InventoryItem { Name = "Noise Cancelling Earbuds", Price = 159.99m, PictureUrl = "https://picsum.photos/seed/earbuds/400/400" },
            new InventoryItem { Name = "Portable Charger", Price = 49.99m, PictureUrl = "https://picsum.photos/seed/charger/400/400" },
            new InventoryItem { Name = "HDMI Cable 2m", Price = 14.99m, PictureUrl = "https://picsum.photos/seed/hdmi/400/400" },
            new InventoryItem { Name = "Microphone USB", Price = 89.99m, PictureUrl = "https://picsum.photos/seed/microphone/400/400" },
            new InventoryItem { Name = "Gaming Mouse Pad", Price = 24.99m, PictureUrl = "https://picsum.photos/seed/mousepad/400/400" }
        };

        // Generate ETag
        var json = JsonSerializer.Serialize(inventories);
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(json));
        var etag = $"\"{Convert.ToHexString(hash).ToLower()}\"";
        
        // Check If-None-Match header
        if (Request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch) && ifNoneMatch == etag)
        {
            return StatusCode(304);
        }
        
        Response.Headers.Append("ETag", etag);
        return Ok(inventories);
    }

    [HttpGet("computers")]
    public async Task<ActionResult<PaginatedResponse<ComputerInventoryItem>>> GetComputerInventories(
        [FromQuery] int limit = 10,
        [FromQuery] int page = 1)
    {
        if (limit <= 0) limit = 10;
        if (page <= 0) page = 1;
        if (limit > 100) limit = 100; // Max limit

        var totalItems = await _context.ComputerInventories.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)limit);

        var items = await _context.ComputerInventories
            .OrderBy(x => x.Id)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();

        var response = new PaginatedResponse<ComputerInventoryItem>
        {
            Items = items,
            Page = page,
            Limit = limit,
            TotalItems = totalItems,
            TotalPages = totalPages,
            HasNextPage = page < totalPages,
            HasPreviousPage = page > 1
        };

        return Ok(response);
    }
}
