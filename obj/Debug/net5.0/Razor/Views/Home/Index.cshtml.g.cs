#pragma checksum "C:\Users\PTN\source\repos\PEADotNetTrainingSolution\PEADotNetTraining\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d908a01950b6cca4683cee5d153f2bd331ab4278"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\PTN\source\repos\PEADotNetTrainingSolution\PEADotNetTraining\Views\_ViewImports.cshtml"
using PEADotNetTraining;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PTN\source\repos\PEADotNetTrainingSolution\PEADotNetTraining\Views\_ViewImports.cshtml"
using PEADotNetTraining.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PTN\source\repos\PEADotNetTrainingSolution\PEADotNetTraining\Views\_ViewImports.cshtml"
using PEADotNetTraining.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\PTN\source\repos\PEADotNetTrainingSolution\PEADotNetTraining\Views\_ViewImports.cshtml"
using PEADotNetTraining.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\PTN\source\repos\PEADotNetTrainingSolution\PEADotNetTraining\Views\_ViewImports.cshtml"
using ReflectionIT.Mvc.Paging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d908a01950b6cca4683cee5d153f2bd331ab4278", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1217bc694fdf518ea2df87be20a8286ba23e960e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\PTN\source\repos\PEADotNetTrainingSolution\PEADotNetTraining\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n    <p>");
#nullable restore
#line 8 "C:\Users\PTN\source\repos\PEADotNetTrainingSolution\PEADotNetTraining\Views\Home\Index.cshtml"
  Write(ViewBag.thaiDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PEADotNetTraining.Services.ThaiDateService _thaiDateService { get; private set; }
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
