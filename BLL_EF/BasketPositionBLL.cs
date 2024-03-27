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
    public class BasketPositionBLL : IBasketPositionBLL
    {
        private WebshopContext webshop = new WebshopContext();

        public bool AddBasketPosition(int userId, int productId, int amount = 1)
        {
            if (amount <= 0)
                return false;

            var user = webshop.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (user == null)
                return false;

            var product = webshop.Products.Where(x => x.Id == productId).FirstOrDefault();

            if (product == null || product.IsActive == false)
                return false;

            webshop.BasketPositions.Add(new Model.BasketPosition
            {
                Product = product,
                User = user,
                Amount = amount
            });

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

            BasketPosition pos = webshop.BasketPositions.Where(x => x.Id == basketPositionId).FirstOrDefault();

            if (pos == null)
                return false;

            pos.Amount = amount;
            webshop.SaveChanges();
            return true;
        }
        List<BasketPositionDTO> GetUserBasketPositions(int userId);
    }
}
