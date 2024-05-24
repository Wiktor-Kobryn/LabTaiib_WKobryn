using BLL;
using DAL;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class ProductService : IProductService
    {
        private readonly WebshopContext webshop;

        public ProductService(WebshopContext webshop)
        {
            this.webshop = webshop;
        }

        public IEnumerable<ProductResponseDTO> GetAllProducts()
        {
            return webshop.Products.Select(x => ToProductResponseDTO(x));
        }

        public IEnumerable<ProductResponseDTO> GetProducts(int page = 0, int pageSize = 10)
        {
            if (page < 0 || pageSize < 0)
            {
                return null;
            }
                
            return webshop.Products.Skip(page*pageSize).Take(pageSize).Select(x=>ToProductResponseDTO(x));
        }

        public IEnumerable<ProductResponseDTO> GetProducts(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return null;
            }

            return webshop.Products.Where(x=>x.Name.Contains(name)).Select(x => ToProductResponseDTO(x));
        }

        public IEnumerable<ProductResponseDTO> GetActiveProducts()
        {
            return webshop.Products.Where(x=>x.IsActive).Select(x => ToProductResponseDTO(x));
        }

        public IEnumerable<ProductResponseDTO> GetProductsSortedAsc()
        {
            return webshop.Products.OrderBy(x=>x.Price).Select(x => ToProductResponseDTO(x));
        }

        public IEnumerable<ProductResponseDTO> GetProductsSortedDesc()
        {
            return webshop.Products.OrderByDescending(x=>x.Price).Select(x => ToProductResponseDTO(x));
        }

        public bool AddProduct(ProductRequestDTO productRequest)
        {
            if (productRequest == null || productRequest.Price <= 0)
                return false;

            Product newProduct = new()
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                Image = productRequest.Image,
                IsActive = productRequest.IsActive
            };

            webshop.Products.Add(newProduct);
            webshop.SaveChanges();
            return true;
        }

        public bool EditProduct(int productId, ProductRequestDTO productRequest)
        {
            if (productRequest == null || productRequest.Price <= 0)
                return false;

            var product = webshop.Products.Where(x => x.Id == productId).FirstOrDefault();
            if (product == null)
                return false;

            product.Name = productRequest.Name;
            product.Price = productRequest.Price;
            product.Image = productRequest.Image;
            product.IsActive = productRequest.IsActive;

            webshop.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int productId)
        {
            var product = webshop.Products.FirstOrDefault((x => x.Id == productId));
            if (product == null)
                return false;

            if (product.BasketPositions?.Count() > 0) //dodatkowe sprawdzenie null
                return false;

            if (product.OrderPositions?.Count() > 0)
                product.IsActive = false;
            else
                webshop.Products.Remove(product);

            webshop.SaveChanges();
            return true;
        }

        public bool ActivateProduct(int productId)
        {
            var product = webshop.Products.Where(x => x.Id == productId).FirstOrDefault();
            if (product == null)
                return false;

            product.IsActive = true;
            webshop.SaveChanges();
            return true;
        }

        private static ProductResponseDTO ToProductResponseDTO(Product product)
        {
            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                IsActive = product.IsActive
            };
        }
    }
}
