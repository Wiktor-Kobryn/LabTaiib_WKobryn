using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDTO> GetAllProducts();
        IEnumerable<ProductResponseDTO> GetProducts(int page = 0, int pageSize = 10);
        IEnumerable<ProductResponseDTO> GetProducts(string name);
        IEnumerable<ProductResponseDTO> GetActiveProducts();
        IEnumerable<ProductResponseDTO> GetProductsSortedAsc();
        IEnumerable<ProductResponseDTO> GetProductsSortedDesc();
        bool AddProduct(ProductRequestDTO productRequest);
        bool EditProduct(int productId, ProductRequestDTO productRequest);
        bool DeleteProduct(int productId);
        bool ActivateProduct(int productId);
        ProductResponseDTO GetSingleProduct(int productId);
    }
}
