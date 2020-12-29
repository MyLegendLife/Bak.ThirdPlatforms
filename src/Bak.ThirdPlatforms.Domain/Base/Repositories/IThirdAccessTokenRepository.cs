using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Bak.ThirdPlatforms.Domain.Base.Repositories
{
    public interface IThirdAccessTokenRepository : IRepository<ThirdAccessToken>
    {
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        Task<string> GetAccessTokenAsync();

        /// <summary>
        /// 更新密钥
        /// </summary>
        /// <returns></returns>
        Task UpdateAccessTokenAsync(string accessToken, int expiresIn);
    }
}