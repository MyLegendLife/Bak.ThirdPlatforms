using Bak.ThirdPlatforms.Application.Contracts.MiniPrograms;
using Bak.ThirdPlatforms.Common.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Bak.ThirdPlatforms.HttpApi.Controllers
{
    [Route("[controller]")]
    public class MiniProgramController : AbpController
    {
        private readonly IMiniProgramService _miniProgramService;

        public MiniProgramController(IMiniProgramService miniProgramService)
        {
            _miniProgramService = miniProgramService;
        }

        /// <summary>
        /// 快速创建小程序
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FastRegisterCreateAsync")]
        //[Authorize]
        public async Task<ServiceResult<string>> FastRegisterCreateAsync(MiniProgramRegisterInput input)
        {
            return await _miniProgramService.FastRegisterAsync(input);
        }


        /// <summary>
        /// 查询创建任务状态
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FastRegisterSearchAsync")]
        //[Authorize]
        public async Task<ServiceResult<string>> FastRegisterSearchAsync(MiniProgramSearchInput input)
        {
            return await _miniProgramService.RegisterSearchAsync(input);
        }

        /// <summary>
        /// 申请开通直播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("applylive")]
        //[Authorize]
        public async Task<ServiceResult<string>> ApplyLiveAsync(string authAccessToken)
        {
            return await _miniProgramService.ApplyLiveAsync(authAccessToken);
        }
    }
}