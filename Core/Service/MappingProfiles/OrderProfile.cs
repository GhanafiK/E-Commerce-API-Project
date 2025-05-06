using AutoMapper;
using DomainLayer.Models.OrderModule;
using Shared.DataTransfareObjects.IdentitiyModuleDtos;
using Shared.DataTransfareObjects.OrderModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    internal class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<AddressDto, OrderAddress>().ReverseMap();
            
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(D => D.DeliveryMethod, O => O.MapFrom(S => S.DeliveryMethod.ShortName));
            
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(D => D.ProductName, O => O.MapFrom(S => S.Product.ProductName))
                .ForMember(D => D.PictureUrl, O => O.MapFrom<OrderItemPictureUrlResolver>());

        }
    }
}
