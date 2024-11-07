using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CartItem
    {
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public required string  PictureUrl { get; set; }
        public required Guid BrandId { get; set; }
        public required Guid TypeId { get; set; }
    }
}