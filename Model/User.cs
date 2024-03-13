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
    public enum UserType
    {
        Admin, Casual
    }

    [Table("USERS")]
    public class User : IEntityTypeConfiguration<User>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Login { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        public UserType Type { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BasketPosition> BasketPositions { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(p=>p.BasketPositions).WithOne(p=>p.User).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Orders).WithOne(p => p.User).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
