#pragma checksum "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\PdfPreview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e6e7d34c4bf84c29a647938a00883252f8e1904"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PdfPreview), @"mvc.1.0.view", @"/Views/PdfPreview.cshtml")]
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
#line 1 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\PdfPreview.cshtml"
using InPlace4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6e7d34c4bf84c29a647938a00883252f8e1904", @"/Views/PdfPreview.cshtml")]
    public class Views_PdfPreview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<__mDocumentFile>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\PdfPreview.cshtml"
  
//    string Path = Server.MapPath("/Downloads/" + @Model.FileName);
    string Base64 = System.Convert.ToBase64String(@Model.File);


#line default
#line hidden
#nullable disable
            WriteLiteral("    <object");
            BeginWriteAttribute("data", " data=", 202, "", 250, 1);
#nullable restore
#line 8 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\PdfPreview.cshtml"
WriteAttributeValue("", 208, "data:application/pdf;base64," + Base64, 208, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"application/pdf\" style=\"width:100%; height:75vh;\">\r\n        If you are unable to view file, you can download from <a");
            BeginWriteAttribute("href", " href=", 373, "", 384, 1);
#nullable restore
#line 9 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\PdfPreview.cshtml"
WriteAttributeValue("", 379, Path, 379, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">here</a> or download\r\n    </object>\r\n");
#nullable restore
#line 11 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\PdfPreview.cshtml"
Write(Html.Hidden("file", Base64));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\PdfPreview.cshtml"
                                ;

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<__mDocumentFile> Html { get; private set; }
    }
}
#pragma warning restore 1591