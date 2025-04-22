using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Service.Specifications;
using ServiceAbstraction;
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

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var specification = new ProductWithBrandAndTypeSpecifications();
            var Products=await _unitOfWork.GetRepository<Product,int>().GetAllAsync(specification);
            var ProductsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Products);
            return ProductsDto;
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
            return _mapper.Map<Product,ProductDTO>(Product);
        }
    }
}
