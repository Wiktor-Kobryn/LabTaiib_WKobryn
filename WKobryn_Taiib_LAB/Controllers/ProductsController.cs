using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private WebshopContext context;
        private ProductService service;

        public ProductsController(WebshopContext context, ProductService service)
        {
            this.context = context;
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> GetProducts()
        {
            return service.GetProducts();
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> GetProducts([FromQuery] int page, [FromQuery] int pageSize)
        {
            return service.GetProducts(page, pageSize);
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> GetProducts([FromQuery] string name)
        {
            return service.GetProducts(name);
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> GetActiveProducts()
        {
            return service.GetActiveProducts();
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> GetProductsSortedAsc()
        {
            return service.GetProductsSortedAsc();
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> GetProductsSortedDesc()
        {
            return service.GetProductsSortedDesc();
        }

        [HttpPost]
        public bool PostProduct([FromBody] ProductRequestDTO productRequest)
        {
            return service.AddProduct(productRequest);
        }

        [HttpPut("{productId}")]
        public bool PutProduct(int productId, [FromBody] ProductRequestDTO productRequest)
        {
            return service.EditProduct(productId, productRequest);
        }

        [HttpDelete("{productId}")]
        public bool DeleteProduct(int productId)
        {
            return service.DeleteProduct(productId);
        }

        [HttpPut("{productId}")]
        public bool ActivateProduct(int productId)
        {
            return service.ActivateProduct(productId);
        }
    }
}
