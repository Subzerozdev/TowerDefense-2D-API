

namespace Services.DTOs
{
    public class GameLevelDto
    {
        public int Id { get; set; }
        public int? Level { get; set; }
        public int? Coin { get; set; }
        public int? Heart { get; set; }
        public List<WaveDto> Waves { get; set; } = new();
    }
}
