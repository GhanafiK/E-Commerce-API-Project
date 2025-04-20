using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork _unitOfWork,IMapper _mapper) : IServiceManager
    {
        private readonly Lazy<IProductServices> _LazyProductServices=new Lazy<IProductServices>(()=>new ProductServices(_unitOfWork,_mapper));
        public IProductServices ProductServices => _LazyProductServices.Value;
    }
}
