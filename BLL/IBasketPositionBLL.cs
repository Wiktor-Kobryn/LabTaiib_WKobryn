using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBasketPositionBLL
    {
        bool AddBasketPosition(int userId, int productId, int amount = 0);
        bool DeleteBasketPosition(int basketPositionId);
        bool ChangeBasketPositionAmount(int basketPositionId, int amount);
        List<BasketPositionDTO> GetUserBasketPositions(int userId);
    }
}
