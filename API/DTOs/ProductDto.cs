using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "Price mut be greater than 0")]
        public decimal Price { get; set; }
        public string Currency { get; set; }
        [Required]
        public string PictureUrl { get; set; } = string.Empty;
        [Required]
        public Guid ProductTypeId { get; set; }
        [Required]
        public Guid ProductBrandId { get; set; }
        public string City { get; set; }
    }
}