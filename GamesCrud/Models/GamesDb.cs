using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesCrud.Models
{
    [Table("Games")]
    public class GamesDb
    {
        [Key]
        public int id { get; set; }
        public string GameName { get; set; }
        public string Description { get; set; }
        public string Developers { get; set; }
        public string CompanyOwner { get; set; }
        public string Category { get; set; }
    }
}
