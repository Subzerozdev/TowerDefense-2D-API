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
            // 1. Logic cập nhật Customer Point (giữ nguyên)
            var customer = await _customerRepo.GetByIdAsync(dto.CustomerId);
            if (customer == null) throw new Exception("Customer not found");

            // Cộng thêm point cho customer
            customer.Point = (customer.Point ?? 0) + dto.Point;
            if (customer.Gameprogress != null)
                customer.Gameprogress.Wave = null;
            await _customerRepo.UpdateAsync(customer);

            if (dto.GameLevelId == 0)
            {
                return new ResultLevelDto();
            }

            var gameLevel = await _gameLevelService.GetByIdAsync(dto.GameLevelId);
            if (gameLevel == null) throw new Exception("Game Level not found");

            // 🚨 2. KIỂM TRA RESULT LEVEL ĐÃ TỒN TẠI CHƯA
            var existingResult = await _resultRepo.GetByCustomerAndLevelAsync(dto.CustomerId, dto.GameLevelId);

            Resultlevel result;
            bool isUpdate = false;

            if (existingResult != null)
            {
                // 3. LOGIC CẬP NHẬT (UPDATE)
                result = existingResult;

                // Chỉ cập nhật Star nếu Star mới cao hơn Star cũ
                if (dto.Star > result.Star)
                {
                    result.Star = dto.Star;
                    isUpdate = true;
                }

                // Không cần làm gì nếu Star mới thấp hơn hoặc bằng Star cũ
            }
            else
            {
                // 4. LOGIC TẠO MỚI (CREATE)
                result = new Resultlevel
                {
                    Star = dto.Star,
                    // 💡 Lưu ý: Tránh tải cả object Customer và GameLevel, 
                    // nên gán trực tiếp ID để tối ưu performance
                    CustomerId = dto.CustomerId,
                    GameLevelId = dto.GameLevelId
                };
                await _resultRepo.AddAsync(result);
                isUpdate = true; // Đánh dấu là đã thay đổi (thêm mới)
            }

            // 5. LƯU THAY ĐỔI (CHỈ KHI CÓ UPDATE HOẶC CREATE)
            if (isUpdate)
            {
                // Nếu là update, chỉ cần gọi Update (hoặc Add/Update kết hợp) và SaveChanges
                if (existingResult != null)
                {
                    await _resultRepo.UpdateAsync(result);
                    // Tùy thuộc vào cách triển khai Repository, có thể cần gọi _resultRepo.UpdateAsync(result)
                }
                // Nếu là Add, đã gọi ở trên
            }

            return new ResultLevelDto
            {
                Id = result.Id,
                Star = result.Star,
                GameLevelId = result.GameLevelId
            };
        }
    }
}
