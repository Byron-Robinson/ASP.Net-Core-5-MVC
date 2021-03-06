#pragma checksum "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\Drink\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b8e4734446f6b496320d00530b09bf80321969e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Drink_Index), @"mvc.1.0.view", @"/Views/Drink/Index.cshtml")]
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
#line 1 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\_ViewImports.cshtml"
using CrowdyCloudBar.UserInterface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\_ViewImports.cshtml"
using CrowdyCloudBar.UserInterface.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\_ViewImports.cshtml"
using CrowdyCloudBar.UserInterface.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\_ViewImports.cshtml"
using CrowdyCloudBar.DomainData.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b8e4734446f6b496320d00530b09bf80321969e", @"/Views/Drink/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cde13a08f1f58b7df10c67039c1afa7a0cc1683", @"/Views/_ViewImports.cshtml")]
    public class Views_Drink_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DrinkViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\Drink\Index.cshtml"
  
    ViewData["Title"] = "Drinks Overview";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row mx-1 bg-white shadow-sm justify-content-center align-items-center\">\r\n    <div class=\"col-sm-9 mt-4\">\r\n        <div class=\"text-center my-4\">\r\n            <h2>");
#nullable restore
#line 10 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\Drink\Index.cshtml"
           Write(Model.CurrentCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        </div>\r\n        <div class=\"row pb-3\">\r\n");
#nullable restore
#line 13 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\Drink\Index.cshtml"
             foreach (Drink drink in Model.Drinks)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\Drink\Index.cshtml"
           Write(await Html.PartialAsync("_DrinksSummaryPartial", drink));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\byron\OneDrive\Desktop\Empired\CrowdyCloudBar\CrowdyCloudBar.UserInterface\Views\Drink\Index.cshtml"
                                                                        
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DrinkViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
