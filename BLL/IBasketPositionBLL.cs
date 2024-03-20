using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBasketPositionBLL
    {
        void AddProductToBasket(ProductDTO product);
        void DeleteProductFromBasket(int id);
        void ChangeAmountOfProduct(int id, int amount);

    }
}
