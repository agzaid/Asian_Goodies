using Asian.Dtos.User;
using Asian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Services.UserService
{
    public interface ICustomerService
    {
       Task<ServiceResponse< List<GetCustomerDto>>> GetAllCustomers();
        Task<ServiceResponse<GetCustomerDto>> GetCustomerById(int id);
        Task<ServiceResponse<List<GetCustomerDto>>> addCustomer(AddCustomerDto newUser);
        Task<ServiceResponse<GetCustomerDto>> UpdateCustomer(UpdateCustomerDto updatedUser);
        Task<ServiceResponse<List<GetCustomerDto>>> DeleteCustomer(int id); 
    }
}
