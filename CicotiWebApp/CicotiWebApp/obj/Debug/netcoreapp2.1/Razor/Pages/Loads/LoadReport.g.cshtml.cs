#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52784822ac738cb0ee3271b7c3c96a88b4a3655d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.Loads.Pages_Loads_LoadReport), @"mvc.1.0.razor-page", @"/Pages/Loads/LoadReport.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Loads/LoadReport.cshtml", typeof(CicotiWebApp.Pages.Loads.Pages_Loads_LoadReport), @"{LoadID?}")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{LoadID?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52784822ac738cb0ee3271b7c3c96a88b4a3655d", @"/Pages/Loads/LoadReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Loads_LoadReport : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
            BeginContext(69, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
  
    ViewData["Title"] = "Load: Reports";
    Layout = "~/Pages/_LayoutDataTables.cshtml";

#line default
#line hidden
            BeginContext(377, 339, true);
            WriteLiteral(@"
<h2>Load Reports</h2>

<div id=""loader""></div>
<label class=""radio-inline""><input type=""radio"" name=""loadRpt"" value=""VwLoadSummary"" checked>Summary</label>
<label class=""radio-inline""><input type=""radio"" name=""loadRpt"" value=""VwLoadDetail"">Per Load Per Invoice Line</label>
<br />

<div class=""form-group"" id=""divStartDate"">
    ");
            EndContext();
            BeginContext(716, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a82ddec62eb4fa78c6cb9d54fc3c195", async() => {
                BeginContext(772, 12, true);
                WriteLiteral("Loading Date");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 24 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
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
            BeginContext(792, 67, true);
            WriteLiteral("\r\n    <div class=\'input-group date\' id=\'datetimepicker1\'>\r\n        ");
            EndContext();
            BeginContext(859, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e2ca154fb4474c57adea46a9b8a080f3", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 26 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
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
            BeginContext(943, 133, true);
            WriteLiteral("\r\n        <span class=\"input-group-addon\">\r\n            <span class=\"glyphicon glyphicon-calendar\"></span>\r\n        </span>\r\n        ");
            EndContext();
            BeginContext(1076, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3935a0eaf62341e88930c64c39b12f0b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 30 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
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
            BeginContext(1147, 70, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"form-group\" id=\"divEndDate\">\r\n    ");
            EndContext();
            BeginContext(1217, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6795708e92d4703b3249f7882ab3964", async() => {
                BeginContext(1271, 12, true);
                WriteLiteral("Loading Date");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 35 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
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
            BeginContext(1291, 67, true);
            WriteLiteral("\r\n    <div class=\'input-group date\' id=\'datetimepicker2\'>\r\n        ");
            EndContext();
            BeginContext(1358, 80, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "db7b133d24374a90bb84a5af9c85eb21", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 37 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
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
            BeginContext(1438, 133, true);
            WriteLiteral("\r\n        <span class=\"input-group-addon\">\r\n            <span class=\"glyphicon glyphicon-calendar\"></span>\r\n        </span>\r\n        ");
            EndContext();
            BeginContext(1571, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0ac4005d27d471f8b853cfb94dbfa1e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 41 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
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
            BeginContext(1640, 270, true);
            WriteLiteral(@"
    </div>
</div>

<div class=""col-xs-12 col-md-4 col-lg-4"">
    <span class=""input-group-btn"">
        <input type=""button"" value=""Create File"" class=""btn btn-default"" id=""exportBtn"" />
    </span>
</div>
<br/>
<div id=""downloadlink"">

</div>

<br />

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1928, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1935, 40, false);
#line 58 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
                EndContext();
                BeginContext(1975, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1982, 47, false);
#line 59 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
Write(await Html.PartialAsync("_ModalConfirmPartial"));

#line default
#line hidden
                EndContext();
                BeginContext(2029, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 60 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(2099, 516, true);
                WriteLiteral(@"    <script type=""text/javascript"">
        var loadRpt;
        var filename = """";
        var rptToSave = {};
        loadRpt = ""VwLoadSummary"";

        function ajaxLoadReports(obj)
        {
            console.log(""Report: in Load Reports Ajax Call: "" + JSON.stringify(obj));
            $.ajax({
                type: ""POST"",
                url: ""/Loads/LoadReport?handler=Export"",
                    headers:
                        {
                            ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(2616, 25, false);
#line 75 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(2641, 2756, true);
                WriteLiteral(@"'
                        },
                    contentType: ""application/json"",
                    dataType: ""json"",
                    beforeSend: function () {
                        $(window).scrollTop(0);
                        $(""#loader"").show();
                    },
                    data: JSON.stringify(obj),
                success: function (data) {
                    $(""#modalHeader"").text(""Processing Load Report Data"");
                    $(""#modalMessage"").text(data);
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
       ");
                WriteLiteral(@" }
        $(document).ready(function ()
        {
          $(""#loader"").hide();
            $('#exportBtn').click(function () {

                $(""#anchor1"").remove();
                var today = new Date();
                var time = today.getHours() + ""-"" + today.getMinutes() + ""-"" + today.getSeconds();
                var date =  today.getFullYear() +""-"" + (today.getMonth() + 1) + ""-"" + today.getDate();
                var datetime = date + ""-"" + time;
                rptToSave.reportName = loadRpt;
                rptToSave.filename = loadRpt + datetime + "".xlsx"";
                rptToSave.reportID = 0;
                rptToSave.reportDate = $('#startDate').val();
                rptToSave.startDate = $('#startDate').val();
                rptToSave.endDate = $('#endDate').val();
                ajaxLoadReports(rptToSave);
                var a = $('<a />');
                filename = ""Test"";
                anchorLink = ""/UploadFiles/Download?filename="" + rptToSave.filename;
     ");
                WriteLiteral(@"           a.attr('href', anchorLink);
                a.attr('id', ""anchor1"");
                //.attr('class', ""download"");
                anchorText = ""Click to download file"";
                a.text(anchorText);
                $('#downloadlink').append(a);
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
                BeginContext(5398, 22, false);
#line 136 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
                       Write(Model.Report.StartDate);

#line default
#line hidden
                EndContext();
                BeginContext(5420, 182, true);
                WriteLiteral("\'\r\n                    }\r\n            );\r\n            $(\'#datetimepicker2\').datetimepicker(\r\n                {\r\n                    format: \"YYYY/MM/DD\",\r\n                    date: \'");
                EndContext();
                BeginContext(5603, 20, false);
#line 142 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
                      Write(Model.Report.EndDate);

#line default
#line hidden
                EndContext();
                BeginContext(5623, 91, true);
                WriteLiteral("\'\r\n                }\r\n            );\r\n        });//Document Ready end.\r\n\r\n    </script>\r\n\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
#line 9 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Loads\LoadReport.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.Loads.LoadReportModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Loads.LoadReportModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Loads.LoadReportModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.Loads.LoadReportModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
