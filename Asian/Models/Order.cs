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
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> orderDetails { get; set; } = new List<OrderDetails>();
    }
}
