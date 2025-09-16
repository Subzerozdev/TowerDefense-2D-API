
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Repository.Model
{
    public class GameInfo
    {
        [Key]
        [ForeignKey("Customer")]
        public string Id { get; set; }
        public int Stars { get; set; }
        public int CurrentLevel { get; set; }
        public int ThunderSkill { get; set; }
        public int BoomSkill { get; set; }

        public Customer Customer { get; set; }
    }
}
