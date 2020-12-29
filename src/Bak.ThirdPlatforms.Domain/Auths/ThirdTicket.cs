using System;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Domain.Base
{
    /// <summary>
    /// 验证票据
    /// </summary>
    public class ThirdTicket : IEntity
    {
        public virtual string ThirdAppID { get; set; }

        public virtual string Ticket { get; set; }

        public virtual DateTime ValidDate { get; set; }

        public object[] GetKeys()
        {
            throw new System.NotImplementedException();
        }
    }
}