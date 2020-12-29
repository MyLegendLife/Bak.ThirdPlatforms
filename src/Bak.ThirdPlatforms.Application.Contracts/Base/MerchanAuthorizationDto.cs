using System;

namespace Bak.ThirdPlatforms.Application.Contracts.Base
{
    public class MerchanAuthorizationDto
    {
        public virtual string AppID { get; set; }

        public virtual string AuthCode { get; set; }

        public virtual string AccessToken { get; set; }

        public virtual string FuncInfo { get; set; }

        public virtual DateTime AccessTokenValidDate { get; set; }

        public virtual DateTime AuthCodeValidDate { get; set; }

        public virtual DateTime AddTime { get; set; }
    }
}