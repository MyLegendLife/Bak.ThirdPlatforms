#pragma checksum "D:\Projects\Bak.ThirdPlatforms\src\Bak.ThirdPlatforms.Web\Views\MiniProgram\CreateAuthPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3573cc88e04c1a6352217eaa97c1b370ead84efe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MiniProgram_CreateAuthPage), @"mvc.1.0.view", @"/Views/MiniProgram/CreateAuthPage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projects\Bak.ThirdPlatforms\src\Bak.ThirdPlatforms.Web\Views\_ViewImports.cshtml"
using Bak.ThirdPlatforms.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\Bak.ThirdPlatforms\src\Bak.ThirdPlatforms.Web\Views\_ViewImports.cshtml"
using Bak.ThirdPlatforms.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3573cc88e04c1a6352217eaa97c1b370ead84efe", @"/Views/MiniProgram/CreateAuthPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cc7dbc6717b380374bcddf00dec8f236a14124e", @"/Views/_ViewImports.cshtml")]
    public class Views_MiniProgram_CreateAuthPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Projects\Bak.ThirdPlatforms\src\Bak.ThirdPlatforms.Web\Views\MiniProgram\CreateAuthPage.cshtml"
  
    ViewData["Title"] = "授权注册页面 - 小程序";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<fieldset class=\"layui-elem-field layui-field-title\" style=\"margin-top: 50px;\">\r\n    <legend>授权注册页面</legend>\r\n    <div class=\"layui-field-box\" style=\"padding: 10px;\">\r\n        ");
#nullable restore
#line 10 "D:\Projects\Bak.ThirdPlatforms\src\Bak.ThirdPlatforms.Web\Views\MiniProgram\CreateAuthPage.cshtml"
   Write(ViewData["Url"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</fieldset>\r\n<div class=\"layui-bg-red\" style=\"margin:10px; width: 100px; font-size: 15px;\">有效期十分钟</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
