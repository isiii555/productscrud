using ProductsMvc.Data.Entities;

namespace ProductsMvc.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public string ImagePath { get; set; } = null!;

        public Category? Category { get; set; }

        public List<Tag>? Tags { get; set; }

    }
}
