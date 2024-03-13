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
    [Table("ORDER_POSITIONS")]
    public class OrderPosition : IEntityTypeConfiguration<OrderPosition>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Column("OrderID"), Required]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId)), Required]
        public Order Order { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder.HasOne(p => p.Order).WithMany(p => p.OrderPositions).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
