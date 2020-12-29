using System;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Domain.Base
{
    public class ThirdAccessToken : IEntity
    {
        public virtual string ThirdAppID { get; set; }

        public virtual string AccessToken { get; set; }

        public virtual DateTime ValidDate { get; set; }

        public object[] GetKeys()
        {
            throw new System.NotImplementedException();
        }
    }
}