using Asian.Dtos.Order;
using Asian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<GetOrderDto>>> GetAllOrders();
        Task<ServiceResponse<List<GetOrderDto>>> AddOdrer(AddOrderDto newOrder);
        Task<ServiceResponse<GetOrderDto>> GetOrderById(int id);
        Task<ServiceResponse<GetOrderDto>> UpdateOrder(UpdateOrderDto updatedOrder);
        Task<ServiceResponse<List<GetOrderDto>>> DeleteOrder(int id);
    }
}
