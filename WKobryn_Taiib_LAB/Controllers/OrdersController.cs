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
        readonly IOrderService service;

        public OrdersController(IOrderService service)
        {
            this.service = service;
        }

        [HttpPost("User/{userId}")]
        public bool PostOrderFromBasket(int userId)
        {
            return service.CreateOrderFromBasket(userId);
        }

        [HttpGet]
        public IEnumerable<OrderResponseDTO> GetAllOrders()
        {
            return service.GetAllOrders();
        }

        [HttpGet("User/{userId}")]
        public IEnumerable<OrderResponseDTO> GetUserOrders(int userId)
        {
            return service.GetUserOrders(userId);
        }

        [HttpGet("{orderId}/OrderPositions")]
        public IEnumerable<OrderPositionResponseDTO> GetOrderPositions(int orderId)
        {
            return service.GetOrderPositions(orderId);
        }
    }
}
