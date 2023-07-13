namespace GameShop.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = " ";
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Make { get; set; } = " ";

    }
}
