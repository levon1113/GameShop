using System.ComponentModel.DataAnnotations;

namespace GameShop.Data.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
