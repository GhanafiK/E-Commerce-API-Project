using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParams
    {
        private const int DefaulPageSize = 5;
        private const int MaxPageSize = 10;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingOptions? SortingOption { get; set; }
        public string? SearchValue { get; set; }

        public int PageIndex { get; set; } = 1;

        private int _pageSize = DefaulPageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value>MaxPageSize? MaxPageSize:value; } 
        }
    }
}
