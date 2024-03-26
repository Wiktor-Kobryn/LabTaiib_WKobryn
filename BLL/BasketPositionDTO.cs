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
    public class BasketPositionDTO
    {
        public ProductDTO Product { get; set; }
        public UserDTO User { get; set; }
        public int Amount { get; set; }
    }
}
