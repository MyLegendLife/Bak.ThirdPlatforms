using System;
using System.Threading.Tasks;
using Bak.ThirdPlatforms.Common.Extensions;

namespace Bak.ThirdPlatforms.Common.Helper
{
    /// <summary>
    /// 外部数据库操作
    /// </summary>
    public class BakHelper
    {
        public static async Task<string> GetVerifyTicket()
        {
            return await Task.Run(() =>
            {
                var table = SqlHelper.ExecuteDataTable("SELECT Ticket FROM Wx_SmallProgramThirdTicketInfo");

                return table.Rows.Count < 1 ? "" : table.Rows[0]["Ticket"].ToString();
            });
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetAccessToken()
        {
            return await Task.Run(() =>
            {
                var table = SqlHelper.ExecuteDataTable("SELECT AccessToken,ValidDate FROM Wx_SmallProgramThirdAccessTokenInfo");

                if (table.Rows.Count < 1)
                    return "";

                var validDate = table.Rows[0]["ValidDate"].ToString().TryToDateTime(DateTime.MinValue);

                return DateTime.Now > validDate.AddMinutes(-10) ? "" : table.Rows[0]["AccessToken"].ToString();
            });
        }

        /// <summary>
        /// 更新令牌
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static async Task UpdateAccessToken(string accessToken, int expiresIn)
        {
            await Task.Run(() =>
            {
                SqlHelper.ExecuteNoQueryString($"UPDATE Wx_SmallProgramThirdAccessTokenInfo " +
                                               $"SET AccessToken = '{accessToken}'," +
                                               $"ValidDate = '{DateTime.Now.AddSeconds(expiresIn)}'");
            });
        }
    }
}