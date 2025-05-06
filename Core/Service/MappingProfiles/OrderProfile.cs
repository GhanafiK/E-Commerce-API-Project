using AutoMapper;
using DomainLayer.Models.OrderModule;
using Shared.DataTransfareObjects.IdentitiyModuleDtos;
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
            CreateMap<AddressDto, OrderAddress>();
        }
    }
}
