using DomainLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    class ProductWithBrandAndTypeSpecifications:BaseSpecifications<Product,int>
    {
        public ProductWithBrandAndTypeSpecifications(int? BrandId, int? TypeId, ProductSortingOptions? SortingOption) :base(p=>(!BrandId.HasValue||p.BrandId==BrandId)
                                                                                                                            &&
                                                                                                                           (!TypeId.HasValue|| p.TypeId==TypeId))
        {
            AddInclude(p => p.productBrand);
            AddInclude(p => p.productType);

            switch (SortingOption)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDesc(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc: 
                    AddOrderBy(p => p.Price); 
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDesc(p => p.Price); 
                    break;
                default:
                    break;
            }
        }

        public ProductWithBrandAndTypeSpecifications(int id):base(p=>p.Id==id)
        {
            AddInclude(p => p.productBrand);
            AddInclude(p => p.productType);
        }
    }
}
