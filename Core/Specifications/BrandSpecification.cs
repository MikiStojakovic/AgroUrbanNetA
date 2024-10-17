using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class BrandSpecification : BaseSpecification<Product, ProductBrand>
    {
        public BrandSpecification()
        {
            AddSelect(x => x.ProductBrand);
            ApplyDistinct();
        }
    }
}