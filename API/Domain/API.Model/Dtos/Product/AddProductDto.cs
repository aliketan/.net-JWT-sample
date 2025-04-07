﻿namespace API.Model.Dtos.Product
{
    public class AddProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
