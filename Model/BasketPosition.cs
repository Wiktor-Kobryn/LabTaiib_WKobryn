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
    [Table("BASKET_POSITIONS")]
    public class BasketPosition : IEntityTypeConfiguration<BasketPosition>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int Amount { get; set; }

        public void Configure(EntityTypeBuilder<BasketPosition> builder)
        {
            builder.HasOne(p => p.Product).WithMany(p => p.BasketPositions).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.User).WithMany(p => p.BasketPositions).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
