
namespace Services.DTOs
{
    public class GameProgressDto
    {
        public int Id { get; set; }
        public int? CurrentCoin { get; set; }
        public int? CurrentHeart { get; set; }
        public int? CurrentPoint { get; set; }
        public int? WaveId { get; set; }
    }
}
