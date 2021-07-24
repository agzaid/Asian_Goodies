using Asian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Dtos.User
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public GenderEnum Gender { get; set; } = GenderEnum.male;
        public string Adrress { get; set; }
        public string City { get; set; }
    }
}
