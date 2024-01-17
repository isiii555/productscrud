namespace ProductsMvc.Models.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public ICollection<int>? TagIds { get; set; }
        public int CategoryId { get; set; }

        public IFormFile Image { get; set; } = null!;
    }
}
