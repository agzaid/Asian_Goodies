using Asian.Data;
using Asian.Dtos.OrderDetails;
using Asian.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Services.OrderDetailsService
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrderDetailsService(DataContext context,IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<ServiceResponse<List<GetOrderDetailsDto>>> AddOrderDetails(AddOrderDetailsDto newOrderDetails)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetOrderDetailsDto>>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetOrderDetailsDto>>> GetAllOrderDetails()
        {
            ServiceResponse<List<GetOrderDetailsDto>> response = new ServiceResponse<List<GetOrderDetailsDto>>();
            try
            {
               List <OrderDetails> orderDetails = await _context.OrderDetails.ToListAsync();
                response.Data = orderDetails.Select(c => _mapper.Map<GetOrderDetailsDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<ServiceResponse<GetOrderDetailsDto>> UpdateUser(UpdateOrderDetailsDto updatedOrderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
