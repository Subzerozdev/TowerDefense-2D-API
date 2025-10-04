
namespace Services.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public double? Point { get; set; }
        public InventoryDto? Inventory { get; set; }
        public GameProgressDto? GameProgress { get; set; }
        public List<ResultLevelDto> ResultLevels { get; set; } = new();
    }
}
