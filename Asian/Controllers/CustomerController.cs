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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<GetCustomerDto>> response = await _service.GetAllCustomers();

            if (response.Data==null)

            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<GetCustomerDto> response = await _service.GetCustomerById(id);

            if (response.Data==null)

            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> addCustomer(AddCustomerDto newCustomer)
        {
            ServiceResponse<List<GetCustomerDto>> response = await _service.addCustomer(newCustomer);

            if (response.Data==null)

            {
                return NotFound();
            }
            return Ok(response);

        } 

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto UpdateCustomer)
        {
            ServiceResponse<GetCustomerDto> response = await _service.UpdateCustomer(UpdateCustomer);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetCustomerDto>> response = await _service.DeleteCustomer(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
