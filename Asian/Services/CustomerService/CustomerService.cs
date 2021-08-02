using Asian.Data;
using Asian.Dtos.User;
using Asian.Models;
using Asian.Services.UserService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Services.Customerservice
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CustomerService(IMapper map, DataContext context)
        {
            _context= context;
            _mapper = map;
        }
        public async Task<ServiceResponse<List<GetCustomerDto>>> addCustomer(AddCustomerDto newcustomer)
        {
            ServiceResponse<List<GetCustomerDto>> serviceResponse = new ServiceResponse<List<GetCustomerDto>>();
            try
            {
                _context.Customers.Add(_mapper.Map<Customer>(newcustomer));
                await _context.SaveChangesAsync();
                List<Customer> Customers = await _context.Customers.ToListAsync();
                serviceResponse.Data = Customers.Select(c => _mapper.Map<GetCustomerDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            //customer.add(newcustomer);
            //serviceResponse.Data = Customers;
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCustomerDto>>> DeleteCustomer(int id)
        {
            ServiceResponse<List<GetCustomerDto>> serviceResponse = new ServiceResponse<List<GetCustomerDto>>();
            try
            {
                Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Customers.Select(s => _mapper.Map<GetCustomerDto>(s)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCustomerDto>>> GetAllCustomers()
        {
            ServiceResponse<List<GetCustomerDto>> serviceResponse = new ServiceResponse<List<GetCustomerDto>>();
            try
            {

                List<Customer> Customers = await _context.Customers.Include(c=>c.Orders).ThenInclude(od=>od.orderDetails).ToListAsync();

                serviceResponse.Data = Customers.Select(c => _mapper.Map<GetCustomerDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCustomerDto>> GetCustomerById(int id)
        {
            ServiceResponse<GetCustomerDto> serviceResponse = new ServiceResponse<GetCustomerDto>();
            try
            {

                Customer customer = await _context.Customers.FirstOrDefaultAsync(c=>c.Id==id);

                serviceResponse.Data = _mapper.Map<GetCustomerDto>(customer);
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            // serviceResponse.Data=_mapper.Map<GetcustomerDto>(Customers.firstorDefault(char=>char.id))
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCustomerDto>> UpdateCustomer(UpdateCustomerDto updatedcustomer)
        {
            ServiceResponse<GetCustomerDto> serviceResponse = new ServiceResponse<GetCustomerDto>();
            try
            {
                Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == updatedcustomer.Id);
                customer.Name = updatedcustomer.Name;
                customer.Adrress = updatedcustomer.Adrress;
                customer.City = updatedcustomer.City;
                customer.Gender = updatedcustomer.Gender;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCustomerDto>(customer);
            }
            catch (Exception ex)
            {

                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;

            }

            return serviceResponse;
        }
    }
}
