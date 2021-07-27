using Asian.Dtos.Order;
using Asian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Dtos.OrderDetails
{
    public class UpdateOrderDetailsDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; } = new DateTime();
        public DateTime? ShippingDate { get; set; }
        public string Status { get; set; } = StatusType.Pending;
        public int orderId { get; set; }
       // public GetOrderDto order { get; set; }
    }
}
