#pragma checksum "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdb716e374e8b84d08a54f99ce9548c25cdde1af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Details.cshtml", typeof(AspNetCore.Views_Home_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdb716e374e8b84d08a54f99ce9548c25cdde1af", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a0910cd8ef2313aac8c4b46c0fcf923b740d6a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlackJack.BLL.Models.GameDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
  
    ViewBag.Title = "Детали игры";

#line default
#line hidden
            BeginContext(93, 225, true);
            WriteLiteral("<table class=\"table table-bordered\">\r\n    <thead class=\"thead-dark\">\r\n        <tr><th>GameID</th><th>User Name</th><th>Balance</th><th>Bet</th><th>Dealer Id</th></tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(319, 13, false);
#line 11 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
           Write(Model.Game.Id);

#line default
#line hidden
            EndContext();
            BeginContext(332, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(356, 26, false);
#line 12 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
           Write(Model.Game.Player.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(382, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(406, 25, false);
#line 13 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
           Write(Model.Game.Player.Balance);

#line default
#line hidden
            EndContext();
            BeginContext(431, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(455, 21, false);
#line 14 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
           Write(Model.Game.Player.Bet);

#line default
#line hidden
            EndContext();
            BeginContext(476, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(500, 20, false);
#line 15 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
           Write(Model.Game.Dealer.Id);

#line default
#line hidden
            EndContext();
            BeginContext(520, 227, true);
            WriteLiteral("</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<table class=\"table table-bordered\">\r\n    <thead class=\"thead-light\">\r\n        <tr><th>Player Step Id</th><th>Player Suite</th><th>Player Rank</th></tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 24 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
         foreach (var item in Model.PlayerStepVM)
        {

#line default
#line hidden
            BeginContext(809, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(848, 7, false);
#line 27 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(855, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(883, 13, false);
#line 28 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.PlayerId);

#line default
#line hidden
            EndContext();
            BeginContext(896, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(924, 10, false);
#line 29 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Suite);

#line default
#line hidden
            EndContext();
            BeginContext(934, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(962, 9, false);
#line 30 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Rank);

#line default
#line hidden
            EndContext();
            BeginContext(971, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 32 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1008, 205, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<table class=\"table table-bordered\">\r\n    <thead class=\"thead-light\">\r\n        <tr><th>Dealer Step Id</th><th>Dealer Suite</th><th>Dealer Rank</th></tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 40 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
         foreach (var item in Model.DealerStepVM)
        {

#line default
#line hidden
            BeginContext(1275, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(1314, 7, false);
#line 43 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1321, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1349, 13, false);
#line 44 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.DealerId);

#line default
#line hidden
            EndContext();
            BeginContext(1362, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1390, 10, false);
#line 45 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Suite);

#line default
#line hidden
            EndContext();
            BeginContext(1400, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1428, 9, false);
#line 46 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Rank);

#line default
#line hidden
            EndContext();
            BeginContext(1437, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 48 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1474, 190, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<table class=\"table\">\r\n    <thead class=\"thead-light\">\r\n        <tr><th>Dealer Step Id</th><th>Dealer Suite</th><th>Dealer Rank</th></tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 56 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
         foreach (var item in Model.BotStepVM)
        {

#line default
#line hidden
            BeginContext(1723, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(1762, 7, false);
#line 59 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1769, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1797, 10, false);
#line 60 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.BotId);

#line default
#line hidden
            EndContext();
            BeginContext(1807, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1835, 10, false);
#line 61 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Suite);

#line default
#line hidden
            EndContext();
            BeginContext(1845, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1873, 9, false);
#line 62 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
               Write(item.Rank);

#line default
#line hidden
            EndContext();
            BeginContext(1882, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 64 "C:\Users\Anuitex - 62\source\repos\Projects1\BlackJack\BlackJack\Views\Home\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1919, 34, true);
            WriteLiteral("    </tbody>        \r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlackJack.BLL.Models.GameDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591