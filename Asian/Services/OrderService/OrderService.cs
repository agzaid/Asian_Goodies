using Asian.Data;
using Asian.Dtos.Order;
using Asian.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mappper;

        public OrderService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mappper = mapper;
        }
        public Task<ServiceResponse<List<GetOrderDto>>> AddOdrer(AddOrderDto newOrder)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetOrderDto>>> DeleteOrder(int id)
        {
            ServiceResponse<List<GetOrderDto>> response = new ServiceResponse<List<GetOrderDto>>();
            try
            {
                Order order = await _context.Orders.FirstOrDefaultAsync(c => c.Id == id);
                _context.Orders.Remove(order);
                await  _context.SaveChangesAsync();
                response.Data = _context.Orders.Select(x => _mappper.Map<GetOrderDto>(x)).ToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetOrderDto>>> GetAllOrders()
        {
            ServiceResponse<List<GetOrderDto>> serviceResponse = new ServiceResponse<List<GetOrderDto>>();
            try
            {
                List<Order> orders = await _context.Orders.ToListAsync();
                serviceResponse.Data = orders.Select(c => _mappper.Map<GetOrderDto>(c)).ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<GetOrderDto>> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetOrderDto>> UpdateOrder(UpdateOrderDto updatedOrder)
        {
            throw new NotImplementedException();
        }
    }
}
