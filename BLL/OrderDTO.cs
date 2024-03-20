﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderPositionDTO> OrderPositions { get; set; }
    }
}