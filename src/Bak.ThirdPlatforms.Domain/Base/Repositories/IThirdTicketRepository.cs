using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Bak.ThirdPlatforms.Domain.Base.Repositories
{
    public interface IThirdTicketRepository : IRepository<ThirdTicket>
    {
        /// <summary>
        /// 获取票据
        /// </summary>
        /// <returns></returns>
        Task<string> GetTicketAsync();
    }
}