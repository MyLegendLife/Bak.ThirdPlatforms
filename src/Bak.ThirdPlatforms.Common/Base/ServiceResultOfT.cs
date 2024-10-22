﻿namespace Bak.ThirdPlatforms.Common.Base
{
    /// <summary>
    /// 服务端响应实体(泛型)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T> : ServiceResult where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public void IsSuccess(T result = null, string message = "")
        {
            Code = Enum.ServiceResultCode.Succeed;
            Message = message;
            Result = result;
        }
    }
}
