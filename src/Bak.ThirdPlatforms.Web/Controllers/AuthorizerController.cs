using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bak.ThirdPlatforms.Application.Contracts.Auths;
using Volo.Abp.Application.Dtos;

namespace Bak.ThirdPlatforms.Web.Controllers
{
    [Route("[controller]")]
    public class AuthorizerController : Controller
    {
        private readonly IAuthorizerService _authorizerService;

        public AuthorizerController(IAuthorizerService authorizerService)
        {
            _authorizerService = authorizerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            //var input = new PagedAndSortedResultRequestDto()
            //{
            //    SkipCount = 0,
            //    MaxResultCount = 10,
            //    Sorting = "AddTime DESC"
            //};

            //var result = await _baseService.QueryMerchanAuthAsync(input);

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("List")]
        public async Task<IActionResult> List(int page, int limit)
        {
            var input = new PagedAndSortedResultRequestDto()
            {
                SkipCount = page - 1,
                MaxResultCount = limit,
                Sorting = "CreationTime DESC"
            };

            var result = await _authorizerService.GetListAsync(input);

            return Json(result);
        }
    }
}
