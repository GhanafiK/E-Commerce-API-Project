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
        //Creating Order Will Take Basket Id , Shipping Address , Delivery Method Id , Customer Email
        //And Return Order Details
        //(Id , UserName , OrderDate , Items (Product Name - Picture Url - Price - Quantity) , Address , Delivery Method Name ,
        //Order Status Value , Sub Total , Total Price  )

        Task<OrderToReturnDto> CreateOrder(OrderDto order,string Email);
    }
}
