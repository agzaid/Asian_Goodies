using Asian.Dtos.Order;
using Asian.Models;
using Asian.Services.OrderService;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<GetOrderDto>> response = await _service.GetAllOrders();
            if (response.Data==null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse < List < GetOrderDto >> response= await _service.DeleteOrder(id);
            if (response.Data==null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
