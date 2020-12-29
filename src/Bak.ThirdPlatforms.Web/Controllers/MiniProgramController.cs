using Bak.ThirdPlatforms.Application.Contracts.Auths;
using Bak.ThirdPlatforms.Application.Contracts.MiniPrograms;
using Bak.ThirdPlatforms.Common.Extensions;
using Bak.ThirdPlatforms.Domain.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Bak.ThirdPlatforms.Web.Controllers
{
    [Route("[controller]")]
    public class MiniProgramController : Controller
    {
        private readonly IAuthorizerService _authorizerService;
        private readonly IMiniProgramService _miniProgramService;

        public MiniProgramController(IMiniProgramService miniProgramService, IAuthorizerService authorizerService)
        {
            _miniProgramService = miniProgramService;
            _authorizerService = authorizerService;
        }

        /// <summary>
        /// 快速创建小程序
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("index")]
        //[Authorize]
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// 快速创建小程序
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("create")]
        //[Authorize]
        public IActionResult Create()
        {
            var selectList = typeof(CodeType).TryToList();//取数据集
            ViewData["CodeType"] = new SelectList(selectList, "Key", "Description");

            return View();
        }

        /// <summary>
        /// 快速创建小程序
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        //[Authorize]
        public async Task<IActionResult> Create([FromBody]MiniProgramRegisterInput input)
        {
            var result = await _miniProgramService.FastRegisterAsync(input);

            return Json(result);
        }

        /// <summary>
        /// 查询创建任务记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("record")]
        //[Authorize]
        public async Task<IActionResult> Record()
        {
            return await Task.FromResult(View());
        }

        /// <summary>
        /// 查询创建任务记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("record")]
        //[Authorize]
        public async Task<IActionResult> Record(int page, int limit)
        {
            var input = new PagedAndSortedResultRequestDto()
            {
                SkipCount = page - 1,
                MaxResultCount = limit,
                Sorting = "CreationTime DESC"
            };

            var result = await _miniProgramService.RecordAsync(input);

            return Json(result);
        }

        /// <summary>
        /// 查询创建任务状态
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("search")]
        //[Authorize]
        public async Task<IActionResult> Search(MiniProgramSearchInput input)
        {
            var result = await _miniProgramService.RegisterSearchAsync(input);

            return Json(result);
        }

        /// <summary>
        /// 授权注册页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("createauthpage")]
        public async Task<IActionResult> CreateAuthPage()
        {
            //获取页面地址转化为回调地址
            var redirectUrl = HttpContext.Request.GetDisplayUrl().Replace("createauthpage", "callback");

            var result = await _authorizerService.CreateAuthPageAsync(redirectUrl);

            ViewData["Url"] = result.Result;

            return View();
        }

        /// <summary>
        /// 回调
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("callback")]
        //[Authorize]
        public async Task<IActionResult> CallBack(string auth_code, int expires_in)
        {
            var result = await _authorizerService.CreateAsync(auth_code, expires_in);

            var content = result.Success ? "授权成功" : result.Message;

            return Content(content);
        }

        /// <summary>
        /// 申请开通直播
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("applylive")]
        //[Authorize]
        public async Task<IActionResult> ApplyLive(string authorizerAppId)
        {
            var result = await _miniProgramService.ApplyLiveAsync(authorizerAppId);

            return Json(result);
        }
    }
}
