

namespace Services.DTOs
{
    public class SpawnPointDto
    {
        public int Id { get; set; }
        public double? DelayAtFirstTime { get; set; }
        public double? DelayEachSpawn { get; set; }
        public List<SpawnDto> Spawns { get; set; } = new();
    }
}
