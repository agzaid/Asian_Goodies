using Asian.Dtos.User;
using Asian.Models;
using Asian.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllUsers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _service.GetUserById(id));
        }
        [HttpPost]
        public async Task<IActionResult> addUser(AddUserDto newUser)
        {
            return Ok(await _service.addUser(newUser));
        } 
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto UpdateUser)
        {
            ServiceResponse<GetUserDto> response = await _service.UpdateUser(UpdateUser);
            if (response.Data==null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
