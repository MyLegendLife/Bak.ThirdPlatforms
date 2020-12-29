namespace Bak.ThirdPlatforms.Application.Contracts.Base
{
    public class MerchanCreateUpdateDto
    {
        public virtual string ThirdAppID { get; set; }
        public virtual string MerchantName { get; set; }
        public virtual string GID { get; set; }
        public virtual string AppID { get; set; }
        public virtual string AppSecret { get; set; }
        public virtual string WxDB { get; set; }
        public virtual string CardDB { get; set; }
        public virtual string WxUrl { get; set; }
        public virtual string ValidDate { get; set; }
        public virtual string PayAppID { get; set; }
        public virtual string PayAppsecret { get; set; }
        public virtual string PayMchid { get; set; }
        public virtual string PaySubMchid { get; set; }
        public virtual string PayKey { get; set; }
        public virtual string SmsBusinNo { get; set; }
        public virtual string SmsBusinKet { get; set; }
        public virtual string SmsServer { get; set; }
        public virtual string SmsBathDate { get; set; }
        public virtual string SmsSendUser { get; set; }
        public virtual string AddTime { get; set; }
    }
}
