#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35a32b40657d66606fc5157e22b39a1c8727d109"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.Loads.Pages_Loads_LoadRpt), @"mvc.1.0.razor-page", @"/Pages/Loads/LoadRpt.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Loads/LoadRpt.cshtml", typeof(CicotiWebApp.Pages.Loads.Pages_Loads_LoadRpt), null)]
namespace CicotiWebApp.Pages.Loads
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\_ViewImports.cshtml"
using CicotiWebApp;

#line default
#line hidden
#line 3 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\_ViewImports.cshtml"
using CicotiWebApp.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35a32b40657d66606fc5157e22b39a1c8727d109", @"/Pages/Loads/LoadRpt.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Loads_LoadRpt : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("startDate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("endDate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
  
    ViewData["Title"] = "Load: Reports";
    Layout = "~/Pages/_LayoutDataTables.cshtml";

#line default
#line hidden
            BeginContext(154, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(363, 347, true);
            WriteLiteral(@"
<h2>Load Reports</h2>

<div id=""loader""></div>
<label class=""radio-inline""><input type=""radio"" name=""loadRpt"" value=""VwLoadSummary"">Summary</label>
<label class=""radio-inline""><input type=""radio"" name=""loadRpt"" value=""VwLoadDetail"" checked>Per Load Per Invoice Line</label>
<br />
<br />

<div class=""form-group"" id=""divStartDate"">
    ");
            EndContext();
            BeginContext(710, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0daa344d33dc43fd8875ccb12b201b13", async() => {
                BeginContext(766, 12, true);
                WriteLiteral("Loading Date");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 26 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Report.StartDate);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(786, 67, true);
            WriteLiteral("\r\n    <div class=\'input-group date\' id=\'datetimepicker1\'>\r\n        ");
            EndContext();
            BeginContext(853, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "00c7adc3acac4ec29241746772eebad6", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 28 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Report.StartDate);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(937, 133, true);
            WriteLiteral("\r\n        <span class=\"input-group-addon\">\r\n            <span class=\"glyphicon glyphicon-calendar\"></span>\r\n        </span>\r\n        ");
            EndContext();
            BeginContext(1070, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81749b6b918b47c785d3a69c117c4118", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 32 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Report.StartDate);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1141, 70, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"form-group\" id=\"divEndDate\">\r\n    ");
            EndContext();
            BeginContext(1211, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc6ccddba6bf4bc8839871f773ddd460", async() => {
                BeginContext(1265, 12, true);
                WriteLiteral("Loading Date");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 37 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Report.EndDate);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1285, 67, true);
            WriteLiteral("\r\n    <div class=\'input-group date\' id=\'datetimepicker2\'>\r\n        ");
            EndContext();
            BeginContext(1352, 80, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ab1a43bc659e4e039a4af86bbc337e85", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 39 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Report.EndDate);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1432, 133, true);
            WriteLiteral("\r\n        <span class=\"input-group-addon\">\r\n            <span class=\"glyphicon glyphicon-calendar\"></span>\r\n        </span>\r\n        ");
            EndContext();
            BeginContext(1565, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8700079aeb744983a7e3aaafc6fa30b2", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 43 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Report.EndDate);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1634, 225, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"col-xs-12 col-md-4 col-lg-4\">\r\n    <span class=\"input-group-btn\">\r\n        <input type=\"button\" value=\"Export\" class=\"btn btn-default\" id=\"exportBtn\" />\r\n    </span>\r\n</div>\r\n\r\n<br />\r\n\r\n\r\n");
            EndContext();
            BeginContext(1860, 40, false);
#line 56 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(1900, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1903, 47, false);
#line 57 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
Write(await Html.PartialAsync("_ModalConfirmPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(1950, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 58 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
  await Html.RenderPartialAsync("_ValidationScriptsPartial"); 

#line default
#line hidden
            BeginContext(2017, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2037, 489, true);
                WriteLiteral(@"

    <script type=""text/javascript"">
        var loadRpt;
        var rptToSave = {};
        loadRpt = ""VwLoadSummary"";

        function ajaxLoadReports(obj)
        {
            console.log(""Report: in Load Reports Ajax Call: "" + JSON.stringify(obj));
            $.ajax({
                type: ""POST"",
                url: ""/Loads/LoadRpt?handler=Export"",
                    headers:
                        {
                            ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(2527, 25, false);
#line 75 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(2552, 1769, true);
                WriteLiteral(@"'
                        },
                    contentType: ""application/json"",
                    dataType: ""json"",
                    data: JSON.stringify(obj),
                success: function (data) {
                    $(""#modalHeader"").text(""Processing Load Report Data"");
                        $(""#modalMessage"").text(""Data DownLoaded"");
                    $(""#myModal"").modal(""show"");
                    $(""#loader"").hide();
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        $(""#modalHeader"").text(""Processing Load Report Data"");
                        $(""#modalMessage"").text(""Data Not DownLoaded"");
                        $(""#myModal"").modal(""show"");
                        $(""#loader"").hide();
                    }
                });//ajax Update / Insert
        }

        $(document).ready(function ()
        {
            $(""#loader"").hide();
            $('#exportBtn').click(function () {
          ");
                WriteLiteral(@"      rptToSave.reportName = loadRpt;
                rptToSave.reportID = 0;
                rptToSave.reportDate = $('#startDate').val();
                rptToSave.startDate = $('#startDate').val();
                rptToSave.endDate = $('#endDate').val();
                ajaxLoadReports(rptToSave);
                return;
            });
            $(""input[type='radio']"").click(function () {
                var radioValue = $(""input[name='loadRpt']:checked"").val();
                if (radioValue) {
                    loadRpt = radioValue;
                }
            });
             $('#datetimepicker1').datetimepicker(
                    {
                     format: ""YYYY/MM/DD"",
                     date: '");
                EndContext();
                BeginContext(4322, 22, false);
#line 116 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
                       Write(Model.Report.StartDate);

#line default
#line hidden
                EndContext();
                BeginContext(4344, 182, true);
                WriteLiteral("\'\r\n                    }\r\n            );\r\n            $(\'#datetimepicker2\').datetimepicker(\r\n                {\r\n                    format: \"YYYY/MM/DD\",\r\n                    date: \'");
                EndContext();
                BeginContext(4527, 20, false);
#line 122 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
                      Write(Model.Report.EndDate);

#line default
#line hidden
                EndContext();
                BeginContext(4547, 89, true);
                WriteLiteral("\'\r\n                }\r\n            );\r\n        });//Document Ready end.\r\n\r\n    </script>\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
#line 10 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadRpt.cshtml"
           
    public string GetAntiXsrfRequestToken()
    {
        return Xsrf.GetAndStoreTokens(Model.HttpContext).RequestToken;
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.Loads.LoadRptModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Loads.LoadRptModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Loads.LoadRptModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.Loads.LoadRptModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
