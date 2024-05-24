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
    public class BasketPositionService : IBasketPositionService
    {
        private readonly WebshopContext webshop;

        public BasketPositionService(WebshopContext webshop)
        {
            this.webshop = webshop;
        }

        public bool AddBasketPosition(BasketPositionRequestDTO basketPositionRequest)
        {
            if (basketPositionRequest.Amount < 0)
                return false;

            var user = webshop.Users.Where(x => x.Id == basketPositionRequest.UserId).FirstOrDefault();
            if (user == null)
                return false;

            var product = webshop.Products.Where(x => x.Id == basketPositionRequest.ProductId).FirstOrDefault();
            if (product == null || product.IsActive == false)
                return false;

            BasketPosition newBasketPosition = new()
            {
                ProductId = basketPositionRequest.ProductId,
                UserId = basketPositionRequest.UserId,
                Amount = basketPositionRequest.Amount
            };

            webshop.BasketPositions.Add(newBasketPosition);
            webshop.SaveChanges();
            return true;
        }

        public bool DeleteBasketPosition(int basketPositionId)
        {
            var deleted = webshop.BasketPositions.Remove(webshop.BasketPositions.SingleOrDefault(x => x.Id == basketPositionId));
            if (deleted == null)
                return false;

            webshop.SaveChanges();
            return true;
        }

        public bool ChangeBasketPositionAmount(int basketPositionId, int amount)
        {
            if (amount <= 0)
                return false;

            var basketPosition = webshop.BasketPositions.SingleOrDefault(x => x.Id == basketPositionId);
            if(basketPosition == null)
                return false;

            basketPosition.Amount = amount;
            webshop.SaveChanges();
            return true;
        }

        public IEnumerable<BasketPositionResponseDTO> GetUserBasketPositions(int userId)
        {
            var user = webshop.Users.Where(x => x.Id == userId).FirstOrDefault();
            if (user == null)
            {
                return null;
            }    

            return webshop.BasketPositions.Where(x => x.UserId == userId).Select(x => ToBasketPositionResponseDTO(x));
        }

        private static BasketPositionResponseDTO ToBasketPositionResponseDTO(BasketPosition basketPosition)
        {
            return new BasketPositionResponseDTO
            {
                Id = basketPosition.Id,
                Amount = basketPosition.Amount,
                ProductId = basketPosition.ProductId,
                UserId = basketPosition.UserId
            };
        }
    }
}
