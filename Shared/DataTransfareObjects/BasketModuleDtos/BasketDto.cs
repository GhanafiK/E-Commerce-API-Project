using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfareObjects.BasketModuleDtos
{
    public class BasketDto
    {
        public string Id { get; set; } = default!; // Guid created from front
        public ICollection<BasketItemDto> Items { get; set; } = [];
    }
}
