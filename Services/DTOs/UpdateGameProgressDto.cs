using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Entities;

namespace Services.DTOs
{
    public class UpdateGameProgressDto
    {
        public int CustomerId { get; set; }
        public int CurrentCoin { get; set; }
        public int CurrentHeart { get; set; }
        public int CurrentPoint { get; set; }
        public int? WaveId { get; set; }
        public List<TowerPlacceDto> Towerplaces { get; set; } = [];
    }
}
