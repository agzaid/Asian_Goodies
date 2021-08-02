using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Dtos.Order
{
    public class AddOrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
    }
}
