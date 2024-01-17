﻿using ProductsMvc.Data.Entities;

namespace ProductsMvc.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;

        public virtual List<Product>? Products { get; set; }

    }
}
