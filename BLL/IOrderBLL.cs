using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IOrderBLL
    {
        void CreateOrderFromBasket(int userId);
        List<OrderDTO> GetAllOrders();
        List<OrderDTO> GetUserOrders(int userId);
        List<OrderPositionDTO> GetOrderPositions(int orderId);
    }
}
