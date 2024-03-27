using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductBLL
    {
        List<ProductDTO> GetAllProducts();
        List<ProductDTO> GetProductsPaged(int page, int pageSize = 10);
        List<ProductDTO> GetProductsByName(string name);
        List<ProductDTO> GetActiveProducts();
        List<ProductDTO> GetProductsSortedAsc();
        List<ProductDTO> GetProductsSortedDesc();
        void AddProduct(ProductDTO product);
        bool EditProduct(int productId, ProductDTO product);
        bool DeleteProduct(int productId);
        bool ActivateProduct(int productId);
    }
}
