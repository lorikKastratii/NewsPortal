#pragma checksum "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0fbb6fe2de92da6d47d898d7ffa148c5dc8632c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_User_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/User/Index.cshtml")]
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
#line 1 "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\_ViewImports.cshtml"
using NewsPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\_ViewImports.cshtml"
using NewsPortal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\_ViewImports.cshtml"
using NewsPortal.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0fbb6fe2de92da6d47d898d7ffa148c5dc8632c", @"/Areas/Admin/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c51f7b45e069d6a3400a8762dc2acbd7635df8", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\User\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1> ");
#nullable restore
#line 7 "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\User\Index.cshtml"
    Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h1>\r\n");
#nullable restore
#line 8 "C:\AspNetProjekti\NewsPortal\NewsPortal\Areas\Admin\Views\User\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>Hello</h1>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591