using System.ComponentModel.DataAnnotations;

namespace GameShop.Data.Entities
{
    public class Make : EntityBase
    {
        [Required]
        public string Name { get; set; } 
        public virtual IEnumerable<Game> Games { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
