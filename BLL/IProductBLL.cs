using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductBLL
    {
        void AddProduct(ProductDTO product);
        void EditProduct(int id, ProductDTO product);
        void DeleteProduct(int id);
        void ActivateProduct(int id);
        List<ProductDTO> GetAllProducts();
        List<ProductDTO> GetProductsByName(string name);
        List<ProductDTO> GetProductsAboveId(int id);
        List<ProductDTO> GetProductsSortedAscending();
        List<ProductDTO> GetProductsSortedDescending();
    }
}
