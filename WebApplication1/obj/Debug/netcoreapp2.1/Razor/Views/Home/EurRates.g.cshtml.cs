#pragma checksum "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\EurRates.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9221d03a1236a36054ee02d69e70634f169425c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EurRates), @"mvc.1.0.view", @"/Views/Home/EurRates.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/EurRates.cshtml", typeof(AspNetCore.Views_Home_EurRates))]
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
#line 1 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#line 2 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9221d03a1236a36054ee02d69e70634f169425c4", @"/Views/Home/EurRates.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EurRates : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.Models.ResponseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 23, true);
            WriteLiteral("\r\n<h2>EurRates</h2>\r\n\r\n");
            EndContext();
#line 5 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\EurRates.cshtml"
  
    ViewData["Title"] = "EurRates";

#line default
#line hidden
            BeginContext(112, 3, true);
            WriteLiteral("<a>");
            EndContext();
            BeginContext(116, 10, false);
#line 8 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\EurRates.cshtml"
Write(Model.Base);

#line default
#line hidden
            EndContext();
            BeginContext(126, 14, true);
            WriteLiteral("</a>\r\n<ul>\r\n\r\n");
            EndContext();
#line 11 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\EurRates.cshtml"
      
        foreach (var vasr in Model.DeserRates)
        {

#line default
#line hidden
            BeginContext(207, 16, true);
            WriteLiteral("            <li>");
            EndContext();
            BeginContext(224, 17, false);
#line 14 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\EurRates.cshtml"
           Write(vasr.CurrencyType);

#line default
#line hidden
            EndContext();
            BeginContext(241, 3, true);
            WriteLiteral(" : ");
            EndContext();
            BeginContext(245, 17, false);
#line 14 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\EurRates.cshtml"
                                Write(vasr.ExchangeRate);

#line default
#line hidden
            EndContext();
            BeginContext(262, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 15 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\EurRates.cshtml"

        }
    

#line default
#line hidden
            BeginContext(289, 5, true);
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Models.ResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
