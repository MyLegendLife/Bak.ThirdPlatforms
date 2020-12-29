namespace Bak.ThirdPlatforms.Domain.Settings
{
    public class UrlsConfig
    {
        /// <summary>
        /// 获取令牌请求地址
        /// </summary>
        public static string GetAccessToken = "https://api.weixin.qq.com/cgi-bin/component/api_component_token";

        /// <summary>
        /// 预授权码
        /// </summary>
        public static string CreatePreAuthCode = "https://api.weixin.qq.com/cgi-bin/component/api_create_preauthcode?component_access_token={0}";

        /// <summary>
        /// 授权注册页面
        /// </summary>
        public static string ComponentLoginPage = "https://mp.weixin.qq.com/cgi-bin/componentloginpage?component_appid={0}&pre_auth_code={1}&redirect_uri={2}&auth_type={3}";

        /// <summary>
        /// 使用授权码获取授权信息
        /// </summary>
        public static string QueryAuth = "https://api.weixin.qq.com/cgi-bin/component/api_query_auth?component_access_token={0}";

        /// <summary>
        /// 获取/刷新接口调用令牌
        /// </summary>
        public static string AuthorizerToken = "https://api.weixin.qq.com/cgi-bin/component/api_authorizer_token?component_access_token={0}";

        /// <summary>
        /// 使用授权者Id获取授权者信息
        /// </summary>
        public static string GetAuthorizerInfo = "https://api.weixin.qq.com/cgi-bin/component/api_get_authorizer_info?component_access_token={0}";

        /// <summary>
        /// 小程序
        /// </summary>
        public static class MiniProgram
        {
            /// <summary>
            /// 创建小程序接口
            /// </summary>
            public static string FastRegisterCreate = "https://api.weixin.qq.com/cgi-bin/component/fastregisterweapp?action=create&component_access_token={0}";

            /// <summary>
            /// 查询创建任务状态
            /// </summary>
            public static string FastRegisterSearch = "https://api.weixin.qq.com/cgi-bin/component/fastregisterweapp?action=search&component_access_token={0}";

            /// <summary>
            /// 申请开通直播
            /// </summary>
            public static string ApplyLive = "https://api.weixin.qq.com/wxa/business/applyliveinfo?access_token={0}";
        }
    }
}