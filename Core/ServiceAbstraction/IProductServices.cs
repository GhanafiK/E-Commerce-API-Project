using Shared;
using Shared.DataTransfareObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductServices
    {
        Task<PaginatedResult<ProductDTO>> GetAllProductsAsync(ProductQueryParams queryParams);
        Task<IEnumerable<BrandDTO>> GetAllBrandsAsync();
        Task<IEnumerable<TypeDTO>> GetAllTypesAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
    }
}
