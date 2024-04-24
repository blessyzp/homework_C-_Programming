using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApp;

namespace assignment9.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        /*        private static readonly string[] Summaries = new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };*/
        /* private readonly ILogger<OrderController> _logger;
 */

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            return _orderService.Orders();
        }

        /*        [HttpGet(Name = "GetWeatherForecast")]
                public IEnumerable<WeatherForecast> Get()
                {
                    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    })
                    .ToArray();
                }*/

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(string id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)
        {
            try
            {
                order.OrderId=Guid.NewGuid().ToString();
                _orderService.AddOrder(order);
                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
            }
            catch (Exception e)
            {
                return BadRequest($"Failed to add order: {e.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Order ID mismatch");
            }
            try
            {
                _orderService.UpdateOrder(order);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest($"Failed to update order: {e.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(string id)
        {
            try
            {
                _orderService.RemoveOrder(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest($"Failed to delete order: {e.Message}");
            }
        }
    }
}
