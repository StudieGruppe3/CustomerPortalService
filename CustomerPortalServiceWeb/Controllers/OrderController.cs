using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerPortalServiceWeb.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/orders")]
public class OrderController : ControllerBase
{
    [HttpPost]
    public IActionResult PlaceOrder([FromBody] PlacedOrder order)
    {
        if (order == null || order.Product == null)
        {
            return BadRequest("Invalid order data.");
        }
        
        order.OrderId = new Random().Next(1000, 9999); // Simulating order ID generation
        order.Date = DateTime.UtcNow;
        
        // Simulate sending the order to other microservices
        Console.WriteLine($"Order {order.OrderId} placed for {order.Customer}, Product: {order.Product.Name}");
        
        return Ok(new { Message = "Order successfully placed", OrderId = order.OrderId });
    }
}

public class PlacedOrder
{
    public int OrderId { get; set; }
    public string Customer { get; set; }
    public Product Product { get; set; }
    public DateTime Date { get; set; }
    public int Amount { get; set; }
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}
