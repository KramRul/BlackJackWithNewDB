#pragma checksum "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\_GetDealerSteps.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df2f435b801e7c6bc4d13559f77b7bc1d319a09f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__GetDealerSteps), @"mvc.1.0.view", @"/Views/Home/_GetDealerSteps.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_GetDealerSteps.cshtml", typeof(AspNetCore.Views_Home__GetDealerSteps))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df2f435b801e7c6bc4d13559f77b7bc1d319a09f", @"/Views/Home/_GetDealerSteps.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a0910cd8ef2313aac8c4b46c0fcf923b740d6a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__GetDealerSteps : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BlackJack.BLL.Models.DealerStepViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 99, true);
            WriteLiteral("<table class=\"table\">\r\n    <tr><th>Step Id</th><th>Dealer Id</th><th>Suite</th><th>Rank</th></tr>\r\n");
            EndContext();
#line 4 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\_GetDealerSteps.cshtml"
     foreach (var step in Model)
    {

#line default
#line hidden
            BeginContext(202, 22, true);
            WriteLiteral("    <tr>\r\n        <td>");
            EndContext();
            BeginContext(225, 7, false);
#line 7 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\_GetDealerSteps.cshtml"
       Write(step.Id);

#line default
#line hidden
            EndContext();
            BeginContext(232, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(252, 13, false);
#line 8 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\_GetDealerSteps.cshtml"
       Write(step.DealerId);

#line default
#line hidden
            EndContext();
            BeginContext(265, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(285, 10, false);
#line 9 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\_GetDealerSteps.cshtml"
       Write(step.Suite);

#line default
#line hidden
            EndContext();
            BeginContext(295, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(315, 9, false);
#line 10 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\_GetDealerSteps.cshtml"
       Write(step.Rank);

#line default
#line hidden
            EndContext();
            BeginContext(324, 18, true);
            WriteLiteral("</td>\r\n    </tr>\r\n");
            EndContext();
#line 12 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\_GetDealerSteps.cshtml"
    }

#line default
#line hidden
            BeginContext(349, 10, true);
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BlackJack.BLL.Models.DealerStepViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
