﻿using System.Collections.Generic;

namespace LaptopMart.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
       
        public string Description { get; set; }
    }
}