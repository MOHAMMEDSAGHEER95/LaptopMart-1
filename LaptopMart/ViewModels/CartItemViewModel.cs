﻿namespace LaptopMart.ViewModels
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }

        public int CartItemId { get; set; }
        
        public int Quantity { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

    }
}