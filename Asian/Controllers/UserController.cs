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
    [Route("[controller]")]
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
            ServiceResponse<List<GetUserDto>> response = await _service.GetAllUsers();
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<GetUserDto> response = await _service.GetUserById(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> addUser(AddUserDto newUser)
        {
            ServiceResponse<List<GetUserDto>> response = await _service.addUser(newUser);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto UpdateUser)
        {
            ServiceResponse<GetUserDto> response = await _service.UpdateUser(UpdateUser);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetUserDto>> response = await _service.DeleteUser(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
