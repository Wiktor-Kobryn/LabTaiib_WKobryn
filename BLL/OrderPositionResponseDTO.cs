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
    public class OrderPositionResponseDTO
    {
        public int Id { get; init; }
        public int OrderId { get; init; }
        public int Amount { get; init; }
        public double Price { get; init; }
        public int ProductId { get; init; }
    }
}
