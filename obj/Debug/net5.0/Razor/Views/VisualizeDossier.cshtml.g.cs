#pragma checksum "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "300a8e8c96a563f3290b60022eab7d2798e79712"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VisualizeDossier), @"mvc.1.0.view", @"/Views/VisualizeDossier.cshtml")]
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
#line 1 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"300a8e8c96a563f3290b60022eab7d2798e79712", @"/Views/VisualizeDossier.cshtml")]
    public class Views_VisualizeDossier : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataSet>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
  
    DataTable Table_0 = null;
    DataTable Table_1 = null;
    DataTable Table_2 = null;

    if (Model.Tables.Count == 2)
    {
        Table_1 = Model.Tables[0];
        Table_2 = Model.Tables[1];
    }
    else
    {

    }


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style type=""text/css"">
    .row {
        margin-right: -30px;
        margin-left: -20px;
        margin-top: -10px;
    }

    .accordion__header {
        padding: 0.5rem 0.75rem;
    }

    .accordion__item {
        margin-bottom: 0.25rem;
    }

    .card-body {
        font-size: 12px;
        padding: 5px;
    }

    .col-xl-7 {
        padding: 0px;
    }
</style>



<!--**********************************
     Content body start
 ***********************************-->
<!-- Row starts -->
<div class=""row"">
    <!-- Column starts -->
    <div class=""col-xl-5"">
        <div class=""card"" style=""height: auto !important;"">
            <div class=""card-header d-block"">
                <h4 class=""card-title"">");
#nullable restore
#line 56 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
                                  Write(Table_2.Rows[0]["id_pratica"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"card-header d-block\">\r\n                <h4 class=\"card-title\">");
#nullable restore
#line 59 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
                                  Write(Table_2.Rows[0]["nominativo"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"card-body scroll\" style=\"overflow-x: hidden\">\r\n                <div id=\"accordion-nine\" class=\"accordion accordion-active-header\">\r\n\r\n");
#nullable restore
#line 64 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
                       int Index = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
                     foreach (DataRow R in Model.Tables[0].Rows)
                    {

                        string Value = R["Label"].ToString().Replace("_", " ");
                        string id = "active-header_collapse__" + Index.ToString();
                        string datatarget = "#active-header_collapse__" + Index.ToString();
                        string Cluster = R["id"].ToString();
                        string __onclick = "GetDocuments('" + Cluster + "&" + id + "&" + Model.DataSetName + "');";


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"accordion__item\">\r\n                            <div class=\"accordion__header collapsed\"");
            BeginWriteAttribute("onclick", " onclick=", 2118, "", 2137, 1);
#nullable restore
#line 75 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
WriteAttributeValue("", 2127, __onclick, 2127, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"collapse\" data-target=");
#nullable restore
#line 75 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
                                                                                                                      Write(datatarget);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n                                <span class=\"accordion__header--icon\"></span>\r\n                                <span class=\"accordion__header--text\">");
#nullable restore
#line 77 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
                                                                 Write(Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span class=\"badge badge-primary badge-pill\" style=\"float:right;\">");
#nullable restore
#line 78 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
                                                                                             Write(R["Total"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                            <div");
            BeginWriteAttribute("id", " id=", 2548, "", 2555, 1);
#nullable restore
#line 80 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
WriteAttributeValue("", 2552, id, 2552, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse accordion__body\" data-parent=\"#accordion-nine\" style=\"cursor:pointer\">\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 83 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"

                        Index++;

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n\r\n\r\n                <div>\r\n\r\n");
#nullable restore
#line 93 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
                      
                        string __onclickgetassets = "GetAssets('" + Model.DataSetName + "');";
                        string __onclickdownloadassets = "DownloadAssets();";

                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>


            </div>
        </div>
    </div>
    <!-- Column ends -->
    <!--<div class=""col-xl-7"">
        <div class=""card"" style=""height: auto !important;"">
            <div class=""container scroll height640"" style=""overflow-x:hidden"">
                <div id=""pdfpreview"" class=""embed-responsive"">-->
");
            WriteLiteral(@"    <!--</div>
            </div>
        </div>
    </div>-->

    <div class=""col-xl-7"">
        <div class=""card scroll"" style=""overflow-x: hidden;"">
            <div class=""container"">
                <input id=""GetAsset"" class=""btn btn-primary btn-xxs"" data-toggle=""modal"" data-target=""#exampleModalCenter"" style=""visibility:hidden;"" type=""button"" value=""Get Asset""");
            BeginWriteAttribute("onclick", " onclick=", 4543, "", 4571, 1);
#nullable restore
#line 125 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
WriteAttributeValue("", 4552, __onclickgetassets, 4552, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input id=\"DownloadAsset\" class=\"btn btn-primary btn-xxs\" style=\"visibility:hidden;\" type=\"button\" value=\"Download Asset\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4713, "\"", 4747, 1);
#nullable restore
#line 126 "E:\InplaceNewProject\InPlace415032021\InPlace4\Views\VisualizeDossier.cshtml"
WriteAttributeValue("", 4723, __onclickdownloadassets, 4723, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                <div id=\"pdfpreview\" style=\"width:100%; height:100%;\">\r\n\r\n");
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Row ends -->\r\n<!--**********************************\r\n    Content body end\r\n***********************************-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataSet> Html { get; private set; }
    }
}
#pragma warning restore 1591