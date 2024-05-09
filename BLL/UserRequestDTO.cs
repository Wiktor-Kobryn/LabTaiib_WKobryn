using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserRequestDTO
    {
        public string Login { get; init; }
        public string Password { get; init; }
        public UserType Type { get; init; }
        public bool IsActive { get; init; }
    }
}
