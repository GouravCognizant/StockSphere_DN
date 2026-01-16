using Microsoft.AspNetCore.Mvc;
using StockSphere_DN.Data;
using StockSphere_DN.Models.DTOs;
using StockSphere_DN.Models.Entities;
using System.Reflection.Metadata.Ecma335;

namespace StockSphere_DN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public OrderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var allOrders = dbContext.Orders.ToList();
            return Ok(allOrders);
        }

        [HttpGet("user/{userId:guid}")] 
        public IActionResult GetOrdersByUserId(Guid userId) 
        {
            var orders = dbContext.Orders.Where(o => o.UserId == userId).ToList(); 
            if (orders == null || orders.Count == 0) 
            { 
                return NotFound(new { Message = "No orders found for this user" }); 
            } 
            return Ok(new { UserId = userId, Orders = orders }); 
        }

        [HttpPost]
        public IActionResult AddOrder(AddOrderDto addOrderDto) 
        {
            var orderEntity = new Order()
            {
                StockSymbol = addOrderDto.StockSymbol,
                Type = addOrderDto.Type,
                Status = addOrderDto.Status,
                OrderQuantity = addOrderDto.OrderQuantity,
                OrderPrice = addOrderDto.OrderPrice,
                UserId = addOrderDto.UserId

            };

            dbContext.Orders.Add(orderEntity);
            dbContext.SaveChanges();
            return Ok(orderEntity);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
