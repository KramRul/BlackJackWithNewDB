#pragma checksum "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\User\AllSteps.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04dd5251789676de23f3771cada4ec186d693ae9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_AllSteps), @"mvc.1.0.view", @"/Views/User/AllSteps.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/AllSteps.cshtml", typeof(AspNetCore.Views_User_AllSteps))]
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
#line 1 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\_ViewImports.cshtml"
using BlackJack;

#line default
#line hidden
#line 2 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\_ViewImports.cshtml"
using BlackJack.BLL.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04dd5251789676de23f3771cada4ec186d693ae9", @"/Views/User/AllSteps.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a0910cd8ef2313aac8c4b46c0fcf923b740d6a1", @"/Views/_ViewImports.cshtml")]
    public class Views_User_AllSteps : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BlackJack.BLL.Models.PlayerStepViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\User\AllSteps.cshtml"
  
    ViewBag.Title = "Список шагов игрока";

#line default
#line hidden
            BeginContext(113, 73, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <tr><th>User Name</th><th>StepId</th></tr>\r\n");
            EndContext();
#line 8 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\User\AllSteps.cshtml"
     foreach (var step in Model)
    {

#line default
#line hidden
            BeginContext(227, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(258, 20, false);
#line 11 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\User\AllSteps.cshtml"
           Write(step.Player.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(278, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(302, 7, false);
#line 12 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\User\AllSteps.cshtml"
           Write(step.Id);

#line default
#line hidden
            EndContext();
            BeginContext(309, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 14 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\User\AllSteps.cshtml"
    }

#line default
#line hidden
            BeginContext(338, 12, true);
            WriteLiteral("</table>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BlackJack.BLL.Models.PlayerStepViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
