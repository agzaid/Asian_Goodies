using Asian.Data;
using Asian.Dtos.User;
using Asian.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(IMapper map, DataContext context)
        {
            _context= context;
            _mapper = map;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> addUser(AddUserDto newUser)
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                _context.Users.Add(_mapper.Map<User>(newUser));
                await _context.SaveChangesAsync();
                List<User> users = await _context.Users.ToListAsync();
                serviceResponse.Data = users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            //User.add(newUser);
            //serviceResponse.Data = Users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                User user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Users.Select(s => _mapper.Map<GetUserDto>(s)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {

                List<User> users = await _context.Users.Include(c=>c.Orders).ToListAsync();

                serviceResponse.Data = users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {

                User user = await _context.Users.FirstOrDefaultAsync(c=>c.Id==id);

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            // serviceResponse.Data=_mapper.Map<GetUserDto>(Users.firstorDefault(char=>char.id))
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                User user = await _context.Users.FirstOrDefaultAsync(c => c.Id == updatedUser.Id);
                user.Name = updatedUser.Name;
                user.Adrress = updatedUser.Adrress;
                user.City = updatedUser.City;
                user.Gender = updatedUser.Gender;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
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
