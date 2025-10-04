
namespace Services.DTOs
{
    public class WaveDto
    {
        public int Id { get; set; }
        public int? WaveLevel { get; set; }
        public int? TotalEnemy { get; set; }
        public List<SpawnPointDto> Spawnpoints { get; set; } = new();
    }
}
