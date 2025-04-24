using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models;
using Service.Specifications;
using ServiceAbstraction;
using Shared;
using Shared.DataTransfareObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductServices(IUnitOfWork _unitOfWork,IMapper _mapper) : IProductServices
    {
        public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
        {
            var Brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var BrandsDto =_mapper.Map<IEnumerable<ProductBrand>,IEnumerable<BrandDTO>>(Brands);
            return BrandsDto;

        }

        public async Task<PaginatedResult<ProductDTO>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            var Repo = _unitOfWork.GetRepository<Product, int>();
            var specification = new ProductWithBrandAndTypeSpecifications(queryParams);
            var Products=await Repo.GetAllAsync(specification);
            var ProductsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Products);
            var ProductCount=Products.Count();
            var TotalCount = await Repo.GetCountAsync(new ProductCountSpecification<Product,int>(queryParams));
            return new PaginatedResult<ProductDTO>(ProductCount,queryParams.PageIndex, TotalCount, ProductsDto);
        }

        public async Task<IEnumerable<TypeDTO>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var BrandsDto = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDTO>>(Types);
            return BrandsDto;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(id);
            var Product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specifications);
            if(Product is null)
                throw new ProductNotFoundException(id);
            return _mapper.Map<Product,ProductDTO>(Product);
        }
    }
}
