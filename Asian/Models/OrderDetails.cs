using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; } =  DateTime.Now;
        public DateTime? ShippingDate { get; set; }
        public string Status { get; set; } = StatusType.Pending;
        public Order order { get; set; }
        public int orderId { get; set; }
    }
}
