using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public double Price { get; set; }
        [MaxLength(100)]
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BasketPosition> BasketPositions { get; set; }
        public IEnumerable<OrderPosition> OrderPositions { get; set; }
    }
}
