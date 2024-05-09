using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBasketPositionService
    {
        bool AddBasketPosition(BasketPositionRequestDTO basketPositionRequest);
        bool DeleteBasketPosition(int basketPositionId);
        bool ChangeBasketPositionAmount(int basketPositionId, int amount);
        IEnumerable<BasketPositionResponseDTO> GetUserBasketPositions(int userId);
    }
}
