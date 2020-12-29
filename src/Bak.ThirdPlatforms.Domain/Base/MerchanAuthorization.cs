using System;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Domain.Base
{
    /// <summary>
    /// 授权码
    /// </summary>
    public class MerchanAuthorization : IEntity
    {
        public virtual string ThirdAppID { get; set; }

        public virtual string AppID { get; set; }

        public virtual string AuthCode { get; set; }

        public virtual string AccessToken { get; set; }

        public virtual string RefreshToken { get; set; }

        public virtual string FuncInfo { get; set; }

        public virtual DateTime AccessTokenValidDate { get; set; }

        public virtual DateTime AuthCodeValidDate { get; set; }

        public virtual DateTime AddTime { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}