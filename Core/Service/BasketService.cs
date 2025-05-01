using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.BasketModule;
using ServiceAbstraction;
using Shared.DataTransfareObjects.BasketModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BasketService(IBasketRepository _basketRepository, IMapper _mapper) : IBasketService
    {
        public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket)
        {
            var CustomerBasket = _mapper.Map<BasketDto, CustomerBasket>(basket);
            var CreateOrUpdateBasket = await _basketRepository.CreateOrUpdateBasketAsync(CustomerBasket);
            if (CreateOrUpdateBasket is not null)
                return await GetBasketAsync(basket.Id);
            else
                throw new Exception("Cant Create Or Update Basket Rignt now, Try again later");
        }

        public async Task<bool> DeleteBasketAsync(string key)=>await _basketRepository.DeleteBasketAsync(key);

        public async Task<BasketDto> GetBasketAsync(string key)
        {
            var Basket=await _basketRepository.GetBasketAsync(key);
            if (Basket is not null)
                return _mapper.Map<CustomerBasket, BasketDto>(Basket);
            else throw new BasketNotFoundException(key);
        }
    }
}
