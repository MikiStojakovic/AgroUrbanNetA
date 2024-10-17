using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class TypeSpecification : BaseSpecification<Product, ProductType>
    {
        public TypeSpecification()
        {
            AddSelect(x => x.ProductType);
            ApplyDistinct();
        }
    }
}