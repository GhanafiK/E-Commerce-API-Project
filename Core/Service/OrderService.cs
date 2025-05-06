using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.BasketModule;
using DomainLayer.Models.OrderModule;
using DomainLayer.Models.ProductModule;
using ServiceAbstraction;
using Shared.DataTransfareObjects.IdentitiyModuleDtos;
using Shared.DataTransfareObjects.OrderModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService(IMapper _mapper,IBasketRepository _basketRepository,IUnitOfWork _unitOfWork) : IOrderService
    {
        public async Task<OrderToReturnDto> CreateOrder(OrderDto orderDto, string Email)
        {
            // mapping address from orderDto to order address
            var OrderAddress = _mapper.Map<AddressDto, OrderAddress>(orderDto.Address);

            //get basket using id 
            var Basket=await _basketRepository.GetBasketAsync(orderDto.BasketId)
                ??throw new BasketNotFoundException(orderDto.BasketId);
            //create order item list
            List<OrderItem> OrderItems = [];
            var ProductRepo = _unitOfWork.GetRepository<Product, int>();
            foreach(var item in Basket.Items)
            {
                var Product = await ProductRepo.GetByIdAsync(item.Id) ?? throw new ProductNotFoundException(item.Id);
                OrderItems.Add(CreateOrderItem(item, Product));
            }

            //Get delivery method
            var DeliveryMethod= await _unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(orderDto.DeliveryMethodId)
                ?? throw new DeliveryMethodNotFoundException(orderDto.DeliveryMethodId);

            //calculate sub total
            var SubTotal = OrderItems.Sum(I => I.Quantity * I.Price);

            var Order=new Order(Email,OrderAddress,DeliveryMethod,OrderItems,SubTotal);

            await _unitOfWork.GetRepository<Order,Guid>().AddAsync(Order);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Order,OrderToReturnDto>(Order);
        }

        private static OrderItem CreateOrderItem(BasketItem item, Product Product)
        {
            return new OrderItem()
            {
                Product = new ProductItemOrdered() { ProductId = Product.Id, PictureUrl = Product.PictureUrl, ProductName = Product.Name },
                Price = Product.Price,
                Quantity = item.Quantity,
            };
        }
    }
}
