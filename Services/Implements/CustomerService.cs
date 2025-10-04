using Repositories.Entities;
using Repositories.Interfaces;
using Services.DTOs;
using Services.Interfaces;
namespace Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<CustomerDto?> RegisterAsync(string username, string password)
        {
            var existing = await _customerRepo.GetByUsernameAsync(username);
            if (existing != null) return null;

            var customer = new Customer
            {
                Username = username,
                Password = password,
                Point = 0,
                Inventory = new Inventory
                {
                    Thunderskill = 0,
                    Boomskill = 0,
                    Upgradepoint = 0,
                    Attackspeed = 0,
                    Damage = 0,
                    Range = 0
                },
                Gameprogress = new Gameprogress
                {
                    Currentcoin = 0,
                    Currentheart = 0,
                    Currentpoint = 0
                }
            };

            var created = await _customerRepo.AddAsync(customer);
            return MapToDto(created);
        }

        public async Task<CustomerDto?> LoginAsync(string username, string password)
        {
            var customer = await _customerRepo.GetByUsernameAsync(username);
            if (customer == null || customer.Password != password) return null;

            return MapToDto(customer);
        }

        public async Task<IEnumerable<(string Username, double Point)>> GetListPointAsync()
        {
            var list = await _customerRepo.GetAllAsync();
            return list
                .OrderByDescending(c => c.Point ?? 0)
                .Select(c => (c.Username, c.Point ?? 0));
        }

        private CustomerDto MapToDto(Customer c)
        {
            return new CustomerDto
            {
                Id = c.Id,
                Username = c.Username,
                Point = c.Point,
                Inventory = c.Inventory == null ? null : new InventoryDto
                {
                    Id = c.Inventory.Id,
                    ThunderSkill = c.Inventory.Thunderskill,
                    BoomSkill = c.Inventory.Boomskill,
                    UpgradePoint = c.Inventory.Upgradepoint,
                    AttackSpeed = c.Inventory.Attackspeed,
                    Damage = c.Inventory.Damage,
                    Range = c.Inventory.Range
                },
                GameProgress = c.Gameprogress == null ? null : new GameProgressDto
                {
                    Id = c.Gameprogress.Id,
                    CurrentCoin = c.Gameprogress.Currentcoin,
                    CurrentHeart = c.Gameprogress.Currentheart,
                    CurrentPoint = c.Gameprogress.Currentpoint,
                    WaveId = c.Gameprogress.WaveId
                },
                ResultLevels = c.Resultlevels.Select(r => new ResultLevelDto
                {
                    Id = r.Id,
                    Star = r.Star,
                    GameLevelId = r.GameLevelId
                }).ToList()
            };
        }
    }
}
