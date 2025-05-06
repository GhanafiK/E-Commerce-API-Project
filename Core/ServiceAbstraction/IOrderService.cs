using Shared.DataTransfareObjects.OrderModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IOrderService
    {
        Task<OrderToReturnDto> CreateOrderAsync(OrderDto order,string Email);

        //Get Delivery Methods
        Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync();

        //Get All Orders
        Task<IEnumerable<OrderToReturnDto>> GetAllOrderAsync(string Email);

        // Get Order By Id
        Task<OrderToReturnDto> GetOrderByIdAsync(Guid Id);
    }
}
