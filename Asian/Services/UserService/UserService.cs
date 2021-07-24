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
             _context.Users.Add(_mapper.Map<User>(newUser));
            //  Users.Add(_mapper.Map<USer>(newUser))
            //User.add(newUser);
            //serviceResponse.Data = Users;
            //return serviceResponse;
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            List<User> users = await _context.Users.ToListAsync();
            serviceResponse.Data = users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
           // serviceResponse.Data=_mapper.Map<GetUserDto>(Users.firstorDefault(char=>char.id))
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();

            throw new NotImplementedException();
        }
    }
}
