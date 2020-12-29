using System;
using System.Threading.Tasks;
using Bak.ThirdPlatforms.Common.Base;

namespace Bak.ThirdPlatforms.Application.Caching.Base
{
    public class BaseCacheService : ThirdPlatformsApplicationCachingServiceBase, IBaseCacheService
    {
        public Task<ServiceResult<string>> CreatePreAuthCode()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<string>> CreatePreAuthCode(Func<Task<ServiceResult<string>>> factory)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<string>> CreateComponentLoginPage(string preAuthCode, string redirectUrl, int authType = 3)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<string>> GetAuthCode()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<string>> QueryAuth()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<string>> GetComponentAccessToken()
        {
            throw new System.NotImplementedException();
        }
    }
}