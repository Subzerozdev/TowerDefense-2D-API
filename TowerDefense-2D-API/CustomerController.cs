using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace TowerDefense_2D_API
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var dto = await _customerService.RegisterAsync(username, password);
            if (dto == null)
                return BadRequest("Username already exists.");

            return Ok(dto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var dto = await _customerService.LoginAsync(username, password);
            if (dto == null)
                return Unauthorized();

            return Ok(dto);
        }

        [HttpGet("points")]
        public async Task<IActionResult> GetListPoint()
        {
            var points = await _customerService.GetListPointAsync();
            return Ok(points.ToList());
        }
    }
}


