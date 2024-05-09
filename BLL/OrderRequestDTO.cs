using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class OrderRequestDTO
    {
        public int UserId { get; init; }
        public DateTime Date { get; init; }
    }
}
