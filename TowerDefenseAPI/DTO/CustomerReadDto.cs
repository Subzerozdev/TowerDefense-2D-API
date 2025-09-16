

namespace TowerDefenseAPI.DTO
{
    public class CustomerReadDto
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public GameInfoReadDto GameInfo { get; set; }
    }
}
