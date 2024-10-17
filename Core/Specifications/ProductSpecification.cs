using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecParams prodParams) : base(x =>
            (string.IsNullOrEmpty(prodParams.Search) || x.Name.ToLower().Contains(prodParams.Search)) &&
            (prodParams.Brands.Count == 0 || prodParams.Brands.Contains(x.ProductBrandId.ToString())) &&
            (prodParams.Types.Count == 0 || prodParams.Types.Contains(x.ProductTypeId.ToString()))
        )
        {
            ApplyPaging(prodParams.PageSize * (prodParams.PageIndex - 1), prodParams.PageSize);
            switch (prodParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }
    }
}