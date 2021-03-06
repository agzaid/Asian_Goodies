using Asian.Dtos.Order;
using Asian.Dtos.OrderDetails;
using Asian.Dtos.User;
using Asian.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<Order, GetOrderDto>();
            CreateMap<OrderDetails, GetOrderDetailsDto>();
        }
    }
}
