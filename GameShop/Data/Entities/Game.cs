using GameShop.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop.Data.Entities
{
    public class Game:EntityBase
    {
        [Required]
        public string  Name { get; set; }
        
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public virtual Genre Genre { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Make")]
        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }
        public bool IsTopGame { get; set; } = false;
        public bool IsTrendingGame { get; set; } = false;
    }
}
