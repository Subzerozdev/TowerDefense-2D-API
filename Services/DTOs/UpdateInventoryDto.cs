
namespace Services.DTOs
{
    public class UpdateInventoryDto
    {
        public int CustomerId { get; set; }
        public int? ThunderSkill { get; set; }
        public int? BoomSkill { get; set; }
        public int? UpgradePoint { get; set; }
        public int? AttackSpeed { get; set; }
        public int? Damage { get; set; }
        public int? Range { get; set; }
    }
}
