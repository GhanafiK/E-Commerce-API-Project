using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    class ProductWithBrandAndTypeSpecifications:BaseSpecifications<Product,int>
    {
        public ProductWithBrandAndTypeSpecifications(int? BrandId, int? TypeId) :base(p=>(!BrandId.HasValue||p.BrandId==BrandId)
                                                                                                &&
                                                                                                (!TypeId.HasValue|| p.TypeId==TypeId))
        {
            AddInclude(p => p.productBrand);
            AddInclude(p => p.productType);
        }

        public ProductWithBrandAndTypeSpecifications(int id):base(p=>p.Id==id)
        {
            AddInclude(p => p.productBrand);
            AddInclude(p => p.productType);
        }
    }
}
