using System;
using System.Collections.Generic;
using Bak.ThirdPlatforms.Domain.Shared.Enums;

namespace Bak.ThirdPlatforms.Application.Contracts.Orders
{
    public class OrderCreateDto 
    {
        public virtual string UserNo { get; set; }

        public virtual long OrderNo { get; set; }

        public virtual OrderType Type { get; set; } = OrderType.Meituan;

        public virtual decimal Money { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        public virtual IEnumerable<OrderLineCreateDto> OrderLines { get; set; }
    }
}
