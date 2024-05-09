using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private WebshopContext context;
        private OrderService service;

        public OrdersController(WebshopContext context, OrderService service)
        {
            this.context = context;
            this.service = service;
        }

        [HttpPost("{id}")]
        public bool PostOrderFromBasket(int userId)
        {
            return service.CreateOrderFromBasket(userId);
        }

        [HttpGet]
        public IEnumerable<OrderResponseDTO> GetAllOrders()
        {
            return service.GetAllOrders();
        }

        [HttpGet]
        public IEnumerable<OrderResponseDTO> GetUserOrders([FromQuery] int userId)
        {
            return service.GetUserOrders(userId);
        }

        [HttpGet]
        public IEnumerable<OrderPositionResponseDTO> GetOrderPositions([FromQuery] int orderId)
        {
            return service.GetOrderPositions(orderId);
        }
    }
}
