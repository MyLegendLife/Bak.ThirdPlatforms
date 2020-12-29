using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Application.Dtos;

namespace Bak.ThirdPlatforms.Application.Contracts.Orders
{
    public class OrderDto //: EntityDto<Guid>
    {
        //public virtual string UserNo { get; set; }

        public virtual long OrderNo { get; set; }

        //public virtual OrderType Type { get; set; }

        public virtual decimal Money { get; set; }

        //public virtual DateTime CreationTime { get; set; }

        public IEnumerable<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();

    }
}
