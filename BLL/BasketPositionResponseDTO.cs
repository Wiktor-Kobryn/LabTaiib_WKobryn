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
    public class BasketPositionResponseDTO
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public int UserId { get; init; }
        public int Amount { get; init; }
    }
}
