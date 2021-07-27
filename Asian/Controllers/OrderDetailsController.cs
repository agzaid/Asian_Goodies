using Asian.Dtos.OrderDetails;
using Asian.Models;
using Asian.Services.OrderDetailsService;
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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _service;

        public OrderDetailsController(IOrderDetailsService service)
        {
            _service = service;
        }

        [HttpGet("GetAllOrderDetails")]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<GetOrderDetailsDto>> response = await _service.GetAllOrderDetails();
            if (response.Data==null)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
