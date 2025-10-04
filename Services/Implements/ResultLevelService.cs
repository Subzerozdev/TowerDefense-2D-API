using Repositories.Entities;
using Repositories.Interfaces;
using Services.DTOs;
using Services.Interfaces;


namespace Services.Implements
{
    public class ResultLevelService : IResultLevelService
    {
        private readonly IResultLevelRepository _resultRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IGameLevelService _gameLevelService;

        public ResultLevelService(IResultLevelRepository resultRepo, ICustomerRepository customerRepo, IGameLevelService gameLevelService)
        {
            _resultRepo = resultRepo;
            _customerRepo = customerRepo;
            _gameLevelService = gameLevelService;
        }

        public async Task<ResultLevelDto> CreateResultLevelAsync(CreateResultLevelDto dto)
        {
            var customer = await _customerRepo.GetByIdAsync(dto.CustomerId);
            if (customer == null) throw new Exception("Customer not found");

            var gameLevel = await _gameLevelService.GetByIdAsync(dto.GameLevelId);
            if (gameLevel == null) throw new Exception("Game Level not found");

            // Tạo ResultLevel mới
            var result = new Resultlevel
            {
                Star = dto.Star,
                Customer = customer,
                GameLevel = gameLevel
            };

            await _resultRepo.AddAsync(result);

            // Cộng thêm point cho customer
            customer.Point = (customer.Point ?? 0) + dto.Point;
            await _customerRepo.UpdateAsync(customer);

            return new ResultLevelDto
            {
                Id = result.Id,
                Star = result.Star,
                GameLevelId = result.GameLevelId
            };
        }
    }
}
