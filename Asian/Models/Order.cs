using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime? Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
