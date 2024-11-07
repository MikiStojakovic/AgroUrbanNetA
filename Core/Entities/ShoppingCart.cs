using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ShoppingCart
    {
        public required Guid Id { get; set; }
        public List<CartItem> Items { get; set; } = [];
    }
}