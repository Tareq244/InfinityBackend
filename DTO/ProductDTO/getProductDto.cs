﻿namespace InfinityBack.DTO.ProductDTO
{
    public class getProductDto
    {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public decimal? Price { get; set; }
            public string ImageUrl { get; set; }

            public List<string> Sizes { get; set; } = new();
            public List<string> Colors { get; set; } = new();
            public List<string> VariantImages { get; set; } = new();
        }
}
