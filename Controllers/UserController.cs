using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace pwa_api.Controllers;

public class User
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string ProfileUrl { get; set; } = string.Empty;
}

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<User>> GetUsers()
    {
        var users = new List<User>
        {
            new User { FirstName = "James105", LastName = "Smith", NickName = "Jimmy", Age = 28, ProfileUrl = "https://robohash.org/james-smith.png?set=set1" },
            new User { FirstName = "Emma5", LastName = "Johnson", NickName = "Em", Age = 24, ProfileUrl = "https://robohash.org/emma-johnson.png?set=set1" },
            new User { FirstName = "Oliver", LastName = "Williams", NickName = "Oli", Age = 31, ProfileUrl = "https://robohash.org/oliver-williams.png?set=set1" },
            new User { FirstName = "Sophia", LastName = "Brown", NickName = "Sophie", Age = 26, ProfileUrl = "https://robohash.org/sophia-brown.png?set=set1" },
            new User { FirstName = "Liam", LastName = "Jones", NickName = "Lee", Age = 29, ProfileUrl = "https://robohash.org/liam-jones.png?set=set1" },
            new User { FirstName = "Ava", LastName = "Garcia", NickName = "Avy", Age = 27, ProfileUrl = "https://robohash.org/ava-garcia.png?set=set1" },
            new User { FirstName = "Noah", LastName = "Martinez", NickName = "Noh", Age = 33, ProfileUrl = "https://robohash.org/noah-martinez.png?set=set1" },
            new User { FirstName = "Isabella", LastName = "Davis", NickName = "Bella", Age = 25, ProfileUrl = "https://robohash.org/isabella-davis.png?set=set1" },
            new User { FirstName = "Ethan", LastName = "Rodriguez", NickName = "Eth", Age = 30, ProfileUrl = "https://robohash.org/ethan-rodriguez.png?set=set1" },
            new User { FirstName = "Mia", LastName = "Wilson", NickName = "Mimi", Age = 23, ProfileUrl = "https://robohash.org/mia-wilson.png?set=set1" },
            new User { FirstName = "Lucas", LastName = "Anderson", NickName = "Luke", Age = 32, ProfileUrl = "https://robohash.org/lucas-anderson.png?set=set1" },
            new User { FirstName = "Charlotte", LastName = "Thomas", NickName = "Charlie", Age = 28, ProfileUrl = "https://robohash.org/charlotte-thomas.png?set=set1" },
            new User { FirstName = "Mason", LastName = "Taylor", NickName = "Mase", Age = 35, ProfileUrl = "https://robohash.org/mason-taylor.png?set=set1" },
            new User { FirstName = "Amelia", LastName = "Moore", NickName = "Amy", Age = 22, ProfileUrl = "https://robohash.org/amelia-moore.png?set=set1" },
            new User { FirstName = "Logan", LastName = "Jackson", NickName = "Lo", Age = 29, ProfileUrl = "https://robohash.org/logan-jackson.png?set=set1" },
            new User { FirstName = "Harper", LastName = "Martin", NickName = "Harp", Age = 26, ProfileUrl = "https://robohash.org/harper-martin.png?set=set1" },
            new User { FirstName = "Elijah", LastName = "Lee", NickName = "Eli", Age = 31, ProfileUrl = "https://robohash.org/elijah-lee.png?set=set1" },
            new User { FirstName = "Evelyn", LastName = "Perez", NickName = "Eve", Age = 24, ProfileUrl = "https://robohash.org/evelyn-perez.png?set=set1" },
            new User { FirstName = "Benjamin", LastName = "White", NickName = "Ben", Age = 27, ProfileUrl = "https://robohash.org/benjamin-white.png?set=set1" },
            new User { FirstName = "Abigail", LastName = "Harris", NickName = "Abby", Age = 25, ProfileUrl = "https://robohash.org/abigail-harris.png?set=set1" }
        };

        // Generate ETag
        var json = JsonSerializer.Serialize(users);
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(json));
        var etag = $"\"{Convert.ToHexString(hash).ToLower()}\"";
        
        // Check If-None-Match header
        if (Request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch) && ifNoneMatch == etag)
        {
            return StatusCode(304);
        }
        
        Response.Headers.Append("ETag", etag);
        // add sleep 5 second 
        System.Threading.Thread.Sleep(5000);
        return Ok(users);
    }

    [HttpGet("user")]
    public ActionResult<object> GetUser([FromQuery] int userId)
    {
        // Mock base64 image (small red dot PNG)
        var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8DwHwAFBQIAX8jx0gAAAABJRU5ErkJggg==";
        
        var user = new
        {
            userId = userId,
            firstName = $"User{userId}FirstName",
            lastName = $"User{userId}LastName",
            imageProfileBase64 = imageBase64
        };

        return Ok(user);
    }

    [HttpGet("user/phones")]
    public ActionResult<List<object>> GetUserPhones([FromQuery] int userId)
    {
        var phones = new List<object>
        {
            new { userId = userId, phone = $"+1-555-{userId:D4}-001" },
            new { userId = userId, phone = $"+1-555-{userId:D4}-002" },
            new { userId = userId, phone = $"+1-555-{userId:D4}-003" }
        };

        return Ok(phones);
    }
}
