using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 5;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public List<Guid> _brands = [];
        public List<string> Brands
        {
            get => _brands.Select(b => b.ToString()).ToList();
            set 
            {
                _brands = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList().Select(id => Guid.Parse(id)).ToList();
            }
        }

        public List<Guid> _types = [];
        public List<string> Types 
        {
            get => _types.Select(t => t.ToString()).ToList();
            set 
            {
               _types = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList().Select(id => Guid.Parse(id)).ToList();
            }
        }

        public string? Sort { get; set; }
        private string? _search;
        public string Search 
        {
            get => _search ?? "";
            set => _search = value.ToLower();
        }
    }
}