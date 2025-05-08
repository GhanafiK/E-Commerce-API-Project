using Shared.DataTransfareObjects.IdentitiyModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfareObjects.OrderModuleDtos
{
    public class OrderDto
    {
        public string BasketId { get; set; } = default!;
        public AddressDto Address { get; set; } = default!;
        public int DeliveryMethodId { get; set; }
    }
}
