
using Repositories.Interfaces;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Implements
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepo;

        public InventoryService(IInventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        public async Task<UpdateInventoryResponseDto?> UpdateInventoryAsync(UpdateInventoryDto dto)
        {
            var inventory = await _inventoryRepo.GetByCustomerIdAsync(dto.CustomerId);
            if (inventory == null) return null;

            // Giả sử "UpgradePoint" là tổng điểm còn lại để nâng cấp
            int usedPoints = (dto.AttackSpeed ?? 0) + (dto.Damage ?? 0) + (dto.Range ?? 0);

            // Cập nhật inventory
            inventory.Thunderskill = dto.ThunderSkill ?? inventory.Thunderskill;
            inventory.Boomskill = dto.BoomSkill ?? inventory.Boomskill;
            inventory.Attackspeed = dto.AttackSpeed ?? inventory.Attackspeed;
            inventory.Damage = dto.Damage ?? inventory.Damage;
            inventory.Range = dto.Range ?? inventory.Range;
            inventory.Upgradepoint = (dto.UpgradePoint ?? inventory.Upgradepoint) - usedPoints;

            await _inventoryRepo.UpdateAsync(inventory);

            return new UpdateInventoryResponseDto
            {
                Inventory = new InventoryDto
                {
                    Id = inventory.Id,
                    ThunderSkill = inventory.Thunderskill,
                    BoomSkill = inventory.Boomskill,
                    AttackSpeed = inventory.Attackspeed,
                    Damage = inventory.Damage,
                    Range = inventory.Range,
                    UpgradePoint = inventory.Upgradepoint
                },
                RemainPoint = inventory.Upgradepoint
            };
        }
    }
}
