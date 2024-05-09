using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IOrderService
    {
        bool CreateOrderFromBasket(int userId);
        IEnumerable<OrderResponseDTO> GetAllOrders();
        IEnumerable<OrderResponseDTO> GetUserOrders(int userId);
        IEnumerable<OrderPositionResponseDTO> GetOrderPositions(int orderId);
    }
}
