#pragma checksum "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ed15beb4a0f2908ae505ffff551cd1c39fcaa42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Login.cshtml", typeof(AspNetCore.Views_Home_Login))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ed15beb4a0f2908ae505ffff551cd1c39fcaa42", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/forms.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\bohdan.khymera\source\repos\WebApplication1\WebApplication1\Views\Home\Login.cshtml"
  
    ViewData["Title"] = "Authorize";

#line default
#line hidden
            BeginContext(47, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1c9528510d774647b06fa0d314b33e44", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(118, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(120, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "72b083f20b094eda87461731d4c9cb8b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(168, 3402, true);
            WriteLiteral(@"
<div class=""containerForm"">
    <div class=""userInfo"" style=""display:none;"">
        <h4>Welcome   <span class=""userName""></span></h4>
        <h4>Your role is   <span id=""userRole""></span></h4>
        <input type=""button"" value=""Log Out"" id=""logOut"" />
    </div>
    <div class=""form-group"">
        <h3>Log In</h3>
        <label>Input email</label><br />
        <input type=""email"" class=""form-control"" id=""emailLogin"" /> <br /><br />
        <label>Input Password</label><br />
        <input type=""password"" class=""form-control"" id=""passwordLogin"" /><br /><br />
        <input class=""btn btn-primary"" type=""submit"" id=""submitLogin"" value=""Login"" />
    </div>
</div>

<script src=""https://code.jquery.com/jquery-2.2.4.min.js""></script>
<script>
    var tokenKey = ""accessToken"";
    $('#submitLogin').click(function (e) {
        e.preventDefault();
        var loginData = {
            Email: $('#emailLogin').val(),
            Password: $('#passwordLogin').val()
        };

        ");
            WriteLiteral(@"var jsonData = JSON.stringify(loginData);
       
        $.ajax({
            type: ""POST"",
            url: '/loginToken',
            contentType: ""application/json"",
            data: JSON.stringify(loginData),
            success: function (inputData){
                var dats = JSON.parse(inputData);
                $('.userName').text(dats.username);
                $('#userRole').text(dats.role);
                $('.userInfo').css('display', 'block');
                $('.loginForm').css('display', 'none');

                setCookie(""Token"", dats.access_token);
                console.log(dats);
            },                
            fail: function (data) {
                console.log(data);
            }
        })
    });

    function setCookie(cname, cvalue) {
        var d = new Date();
        d.setTime(d.getTime() + (24 * 60 * 60 * 1000));
        var expires = ""expires="" + d.toUTCString();
        document.cookie = cname + ""="" + cvalue + "";"" + expires + "";path=/""");
            WriteLiteral(@";
    }

    $('#logOut').click(function (e) {
        e.preventDefault();
        $('.loginForm').css('display', 'block');
        $('.userInfo').css('display', 'none');
        sessionStorage.removeItem(tokenKey);
    });

    $('#getDataByLogin').click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'GET',
            url: '/api/values/getlogin',
            beforeSend: function (xhr) {

                var token = sessionStorage.getItem(tokenKey);
                xhr.setRequestHeader(""Authorization"", ""Bearer "" + token);
            },
            success: function (data) {
                alert(data);
            },
            fail: function (data) {
                console.log(data);
            }
        });
    });
    $('#getDataByRole').click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'GET',
            url: '/api/values/getrole',
            beforeSend: function (xhr) {

                var token = s");
            WriteLiteral(@"essionStorage.getItem(tokenKey);
                xhr.setRequestHeader(""Authorization"", ""Bearer "" + token);
            },
            success: function (data) {
                alert(data);
            },
            fail: function (data) {
                console.log(data);
            }
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
