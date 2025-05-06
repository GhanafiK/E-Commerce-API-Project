using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransfareObjects.OrderModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize]
    public class OrdersController(IServiceManager _serviceManager):ApiBaseController
    {
        //create Order
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
        {
            var Order= await _serviceManager.OrderService.CreateOrderAsync(orderDto,GetEmailFromToken());
            return Ok(Order);
        }

        // Get Delivery Methods
        [AllowAnonymous]
        [HttpGet("DeliveryMethods")]
        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethods()
        {
            var DeliveryMethods= await _serviceManager.OrderService.GetDeliveryMethodsAsync();
            return Ok(DeliveryMethods);
        }

        // Get All Orders By Email
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetAllOrders()
        {
            var Orders = await _serviceManager.OrderService.GetAllOrderAsync(GetEmailFromToken());
            return Ok(Orders);
        }

        //Get Order By Id
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid id)
        {
            var order=await _serviceManager.OrderService.GetOrderByIdAsync(id);
            return Ok(order);
        }

    }
}
