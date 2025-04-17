using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransfareObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().
                ForMember(dest => dest.BrandName, Options =>
                Options.MapFrom(src => src.productBrand.Name))
                .ForMember(dest => dest.TypeName, Options =>
                Options.MapFrom(src => src.productType.Name))
                .ForMember(dest => dest.PictureUrl, Options => Options.MapFrom<PictureUrlResolver>());

            CreateMap<ProductBrand, BrandDTO>();
            CreateMap<ProductType, TypeDTO>();

        }
    }
}
