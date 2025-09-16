using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Model;
using Service.Interfaces;
using TowerDefenseAPI.DTO;

namespace TowerDefenseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public AuthController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerCreateDto dto)
        {
            var existing = (await _customerService.GetAllAsync())
                            .FirstOrDefault(c => c.Username == dto.Username);

            if (existing != null)
                return BadRequest("Username already exists");

            var customer = _mapper.Map<Customer>(dto);
            customer.Id = Guid.NewGuid().ToString();

            // Hash password trước khi lưu
            customer.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // Tạo GameInfo mặc định
            customer.GameInfo = new GameInfo
            {
                Id = customer.Id,
                Stars = 0,
                CurrentLevel = 1,
                ThunderSkill = 0,
                BoomSkill = 0
            };

            await _customerService.CreateAsync(customer);

            return Ok(_mapper.Map<CustomerReadDto>(customer));
        }


        // Login (simple, không JWT)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomerCreateDto dto)
        {
            var customers = await _customerService.GetAllAsync();
            var customer = customers.FirstOrDefault(c => c.Username == dto.Username);

            if (customer == null)
                return Unauthorized("Invalid username or password");

            // So sánh hash
            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, customer.Password);
            if (!isValid)
                return Unauthorized("Invalid username or password");

            return Ok(_mapper.Map<CustomerReadDto>(customer));
        }

    }
}
