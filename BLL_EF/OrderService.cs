using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderService : IOrderService
    {
        private readonly WebshopContext webshop;

        public OrderService(WebshopContext webshop)
        {
            this.webshop = webshop;
        }

        public bool CreateOrderFromBasket(int userId)
        {
            var user = webshop.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
                return false;

            var basketPositions = webshop.BasketPositions.Where(x => x.UserId == userId).ToList();
            if (basketPositions == null || basketPositions.Count() <= 0)
                return false;

            Order order = new()
            {
                UserId = userId,
                Date = DateTime.Now,
            };
            webshop.Orders.Add(order);
            webshop.SaveChanges();

            foreach(BasketPosition bp in basketPositions)
            {
                Product p = webshop.Products.FirstOrDefault(x => x.Id == bp.ProductId);

                OrderPosition op = new()
                {
                    OrderId = order.Id,
                    Amount = bp.Amount,
                    Price = p.Price,
                    ProductId = bp.ProductId
                };
                webshop.OrderPositions.Add(op);
            }

            webshop.BasketPositions.RemoveRange(basketPositions);
            webshop.SaveChanges();
            return true;
        }
        
        public IEnumerable<OrderResponseDTO> GetAllOrders()
        {
            return webshop.Orders.Select(x => ToOrderResponseDTO(x));
        }

        public IEnumerable<OrderResponseDTO> GetUserOrders(int userId)
        {
            return webshop.Orders.Where(x => x.UserId == userId).Select(x => ToOrderResponseDTO(x));
        }

        public IEnumerable<OrderPositionResponseDTO> GetOrderPositions(int orderId)
        {
            return webshop.OrderPositions.Where(x => x.OrderId == orderId).Select(x=>ToOrderPositionResponseDTO(x));
        }

        private static OrderResponseDTO ToOrderResponseDTO(Order order)
        {
            return new OrderResponseDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                Date = order.Date
            };
        }

        private static OrderPositionResponseDTO ToOrderPositionResponseDTO(OrderPosition orderPosition)
        {
            return new OrderPositionResponseDTO
            {
                Id = orderPosition.Id,
                OrderId = orderPosition.OrderId,
                ProductId = orderPosition.ProductId,
                Amount = orderPosition.Amount,
                Price = orderPosition.Price
            };
        }
    }
}
