﻿using System.Linq;
using System.Threading.Tasks;
using Bak.ThirdPlatforms.Common.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Bak.ThirdPlatforms.Application.Caching
{
    public class ThirdPlatformsApplicationCachingServiceBase
    {
        public IDistributedCache Cache { get; set; }

        public async Task RemoveAsync(string key, int cursor = 0)
        {
            var scan = await RedisHelper.ScanAsync(cursor);
            var keys = scan.Items;

            if (keys.Any() && key.IsNotNullOrEmpty())
            {
                keys = keys.Where(x => x.StartsWith(key)).ToArray();

                await RedisHelper.DelAsync(keys);
            }
        }
    }

    public interface ICacheRemoveService
    {
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        Task RemoveAsync(string key, int cursor = 0);
    }
}