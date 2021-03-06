using Asian.Dtos.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Dtos.Order
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public List<GetOrderDetailsDto> orderDetails { get; set; } = new List<GetOrderDetailsDto>();
    }
}
