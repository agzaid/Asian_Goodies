using Asian.Dtos.OrderDetails;
using Asian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Services.OrderDetailsService
{
    public interface IOrderDetailsService
    {
        Task<ServiceResponse<List<GetOrderDetailsDto>>> GetAllOrderDetails();
        Task<ServiceResponse<List<GetOrderDetailsDto>>> AddOrderDetails(AddOrderDetailsDto newOrderDetails);
        Task<ServiceResponse<GetOrderDetailsDto>> UpdateUser(UpdateOrderDetailsDto updatedOrderDetails);
        Task<ServiceResponse<List<GetOrderDetailsDto>>> DeleteUser(int id);
    }
}
