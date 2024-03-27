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
    public class ProductBLL : IProductBLL
    {
        private WebshopContext webshop = new WebshopContext();

        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> products = webshop.Products
                .Select(t => new ProductDTO
                {
                    Name = t.Name,
                    Price = t.Price,
                    Image = t.Image,
                    IsActive = t.IsActive
                }).ToList();

            return products;
        }
        public List<ProductDTO> GetProductsPaged(int page, int pageSize = 10)
        {
            List<ProductDTO> products = webshop.Products
                .Skip(pageSize*page).Take(page)
                .Select(t => new ProductDTO
                {
                    Name = t.Name,
                    Price = t.Price,
                    Image = t.Image,
                    IsActive = t.IsActive
                }).ToList();

            return products;
        }

        public List<ProductDTO> GetProductsByName(string name)
        {
            List<ProductDTO> products = webshop.Products
                .Where(t => t.Name.Contains(name))
                .Select(t => new ProductDTO
                {
                    Name = t.Name,
                    Price = t.Price,
                    Image = t.Image,
                    IsActive = t.IsActive
                }).ToList();

            return products;
        }

        public List<ProductDTO> GetActiveProducts()
        {
            List<ProductDTO> products = webshop.Products
                .Where(t => t.IsActive == true)
                .Select(t => new ProductDTO
                {
                    Name = t.Name,
                    Price = t.Price,
                    Image = t.Image,
                    IsActive = t.IsActive
                }).ToList();

            return products;
        }

        public List<ProductDTO> GetProductsSortedAsc()
        {
            List<ProductDTO> products = webshop.Products
                .OrderBy(x =>x.Price)
                .Select(t => new ProductDTO
                {
                    Name = t.Name,
                    Price = t.Price,
                    Image = t.Image,
                    IsActive = t.IsActive
                }).ToList();

            return products;
        }

        public List<ProductDTO> GetProductsSortedDesc()
        {
            List<ProductDTO> products = webshop.Products
                .OrderByDescending(x => x.Price)
                .Select(t => new ProductDTO
                {
                    Name = t.Name,
                    Price = t.Price,
                    Image = t.Image,
                    IsActive = t.IsActive
                }).ToList();

            return products;
        }

        public void AddProduct(ProductDTO product)
        {
            if(product.Price > 0.0)
            {
                webshop.Products.Add(new Model.Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    IsActive = product.IsActive
                });
                webshop.SaveChanges();
            }
        }

        public bool EditProduct(int productId, ProductDTO product)
        {
            if (product.Price > 0.0)
            {
                var p = webshop.Products.Where(t => t.Id == productId).FirstOrDefault();
                if (p == null)
                    return false;

                p.Name = product.Name;
                p.Price = product.Price;
                p.Image= product.Image;
                p.IsActive = product.IsActive;

                webshop.SaveChanges();
            }
            return true;
        }

        public bool DeleteProduct(int productId)
        {
            var p = webshop.Products.Where(t => t.Id == productId).FirstOrDefault();
            if (p == null)
                return false;

            return false;
            //do dokończenia
        }

        public bool ActivateProduct(int productId)
        {
            var p = webshop.Products.Where(t => t.Id == productId).FirstOrDefault();
            if (p == null)
                return false;

            p.IsActive = true;
            webshop.SaveChanges();
            return true;
        }
    }
}
