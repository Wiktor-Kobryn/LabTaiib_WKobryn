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
    public class ProductRequestDTO
    {
        public string Name { get; init; }
        public double Price { get; init; }
        public string Image { get; init; }
        public bool IsActive { get; init; }
    }
}
