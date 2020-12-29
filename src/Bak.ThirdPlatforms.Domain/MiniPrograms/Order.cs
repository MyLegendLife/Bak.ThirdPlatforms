using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Bak.ThirdPlatforms.Domain.Shared.Enums;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Domain.MiniPrograms
{
    public class Order : AggregateRoot<Guid>, IHasCreationTime
    {
        public virtual string UserNo { get; protected set; }

        public virtual long OrderNo { get; protected set; }

        public virtual OrderType Type { get; protected set; }

        public virtual decimal Money { get; protected set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual Collection<OrderLine> OrderLines { get; protected set; }

        protected Order()
        {

        }

        public Order(
            Guid id,
            [NotNull] string userNo,
            long orderNo,
            OrderType type,
            decimal money)
        {
            Id = id;
            UserNo = Check.NotNullOrWhiteSpace(userNo, nameof(userNo)); //验证
            OrderNo = orderNo;
            Type = type;
            Money = money;

            OrderLines = new Collection<OrderLine>(); //总是初始化子集合
        }
    }

    public class OrderLine : Entity
    {
        public virtual Guid OrderId { get; private set; }

        public virtual string ProductNo { get; protected set; }

        public virtual string ProductName { get; protected set; }

        public virtual decimal Price { get; protected set; }

        public virtual decimal Quantity { get; protected set; }

        public virtual decimal Amount { get; protected set; }

        protected OrderLine()
        {

        }

        public OrderLine(Guid orderId, string productNo, string productName, decimal price, decimal quantity)
        {
            OrderId = orderId;
            ProductNo = productNo;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            Amount = price * quantity;
        }

        public override object[] GetKeys()
        {
            return new Object[] { OrderId, ProductNo };
        }
    }
}
