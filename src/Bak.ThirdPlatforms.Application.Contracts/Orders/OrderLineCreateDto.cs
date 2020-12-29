using System;
using System.Collections.Generic;
using System.Text;

namespace Bak.ThirdPlatforms.Application.Contracts.Orders
{
    public class OrderLineCreateDto
    {
        public virtual Guid OrderId { get; set; }

        public virtual string ProductNo { get; set; }

        public virtual string ProductName { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal Quantity { get; set; }

        public virtual decimal Amount { get; set; }
    }
}
