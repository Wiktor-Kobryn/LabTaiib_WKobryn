using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductDTO : IProductBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BasketPositionDTO> BasketPositions { get; set; }
        public IEnumerable<OrderPositionDTO> OrderPositions { get; set; }

        public void ActivateProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(int id, ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProductsAboveId(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProductsSortedAscending()
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProductsSortedDescending()
        {
            throw new NotImplementedException();
        }
    }
}
