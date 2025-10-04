
namespace Services.DTOs
{
    public class SpawnDto
    {
        public int Id { get; set; }
        public int? EnemyNumber { get; set; }
        public string? EnemyType { get; set; }
        public int? Priority { get; set; }
    }
}
