#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6937795fa0592224976fa7ea90011e420514caa6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.StockCount.Pages_StockCount_StockCountSummary), @"mvc.1.0.razor-page", @"/Pages/StockCount/StockCountSummary.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/StockCount/StockCountSummary.cshtml", typeof(CicotiWebApp.Pages.StockCount.Pages_StockCount_StockCountSummary), null)]
namespace CicotiWebApp.Pages.StockCount
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6937795fa0592224976fa7ea90011e420514caa6", @"/Pages/StockCount/StockCountSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_StockCount_StockCountSummary : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "FindSKU", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
  
    Layout = "_LayoutDataTables";

#line default
#line hidden
            BeginContext(317, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Pages/_LayoutDataTables.cshtml";

#line default
#line hidden
            BeginContext(410, 58, true);
            WriteLiteral("\r\n<br />\r\n<h2>Stock Count Summary Report</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(468, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c79d793f1bea452ab3228eadc122be71", async() => {
                BeginContext(490, 19, true);
                WriteLiteral("Back to SKU Listing");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(513, 538, true);
            WriteLiteral(@"
</p>

<div id=""divStockCountTable"" style=""width:90%; margin:0 auto;"">
    <table id=""StockCountTable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>No of Counts</th>
                <th>Code</th>
                <th>Description</th>
                <th>Qty</th>
                <th>Quality</th>
                <th>UOM</th>
                <th>Principal</th>
            </tr>
        </thead>
    </table>
</div>


");
            EndContext();
            BeginContext(1052, 40, false);
#line 43 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(1092, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1114, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1121, 40, false);
#line 46 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
                EndContext();
                BeginContext(1161, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1168, 47, false);
#line 47 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
Write(await Html.PartialAsync("_ModalConfirmPartial"));

#line default
#line hidden
                EndContext();
                BeginContext(1215, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 48 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(1285, 1033, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function ()
        {

            $(""#StockCountTable"").on('xhr.dt', function (e, settings, json, xhr) {
            }).DataTable({
                lengthMenu: [10,25, 100, 150, 200],
                dom: '<lfB<t>ip>',
                buttons: ['excel', 'copy', 'csv', 'pdf', 'print'],
                ""fixedHeader"": {
                    ""header"": true,
                    ""footer"": true
                },
                ""responsive"": true,
                ""processing"": true, // for show progress bar
                ""serverSide"": true, // for process server side
                ""filter"": true, // this is for disable filter (search box)
                ""orderMulti"": false, // for disable multiple column at once
                ""ajax"": {
        
                    ""url"": ""/StockCount/StockCountSummary?handler=Paging"",
                     ""headers"":
                        {
                            ""RequestVerification");
                WriteLiteral("Token\": \'");
                EndContext();
                BeginContext(2319, 25, false);
#line 73 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(2344, 3677, true);
                WriteLiteral(@"'
                        },
                    ""type"": ""POST"",
                    /*""contentType"": ""application/x-www-form-urlencoded"",*/
                    ""datatype"": ""json""
                },
                ""columnDefs"":
                [   {
                        /*No of Counts is visible and is searchable*/
                        ""targets"": [0],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*SKU Code is visible and is not searchable*/
                        ""targets"": [1],
                        ""visible"": true,
                        ""searchable"": true,
                        ""orderable"": true
                    },
                    {
                        /*SKU Description is visible and is not searchable*/
                        ""targets"": [2],
                        ""visible"": true,
                        ""searchable"": true,
                        """);
                WriteLiteral(@"orderable"": true
                    },
                    {
                        /*Qty*/
                        ""targets"": [3],
                        ""visible"": true,
                        ""searchable"": true,
                        ""orderable"": true
                    },
                    {
                        /*Quality*/
                        ""targets"": [4],
                        ""visible"": true,
                        ""searchable"": true,
                        ""orderable"": true
                    },
                    {
                        /*UOM*/
                        ""targets"": [5],
                        ""visible"": true,
                        ""searchable"": true,
                        ""orderable"": true
                    },
                    {
                        /*Principle  is  visible and is not searchable*/
                        ""targets"": [6],
                        ""visible"": true,
                        ""searchable"": true,
");
                WriteLiteral(@"                        ""orderable"": false
                    }
                ],
                ""columns"": [
                    { ""data"": ""noOfCounts"", ""name"": ""noOfCounts"", ""autoWidth"": true },
                    { ""data"": ""code"", ""name"": ""code"", ""autoWidth"": true },
                    { ""data"": ""description"", ""name"": ""description"", ""autoWidth"": true },
                    { ""data"": ""qty"", ""name"": ""qty"", ""autoWidth"": true },
                    { ""data"": ""quality"", ""name"": ""quality"", ""autoWidth"": true },
                    { ""data"": ""uom"", ""name"": ""uom"", ""autoWidth"": true },
                    { ""data"": ""principleName"", ""name"": ""principleName"", ""autoWidth"": true }
                ]
                });//Stock Count Table
        });//Document Ready end.

        function DeleteData(stockCountItemID)
     {
            if (confirm(""Are you sure you want to delete this stock count item ...?""))
            {
                console.log(""stockCode to be deleted is: "" + stockCountItemID");
                WriteLiteral(@")
                Delete(stockCountItemID);
            }
            else
            {
                return false;
            }
     }

        function Delete(stockCountItemID)
        {
            console.log(""Before Ajax Call:"" + ""Stock Count ID is: "" + stockCountItemID)
            var obj = {};
            obj.StockCountItemID = stockCountItemID;


            $.ajax({
                type: ""DELETE"",
                url: '/StockCount/StockCountListing?handler=Delete',
                headers:
                    {
                        ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(6022, 25, false);
#line 166 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(6047, 952, true);
                WriteLiteral(@"'
                    },
                contentType: ""application/json"",
                dataType: ""json"",
                data: JSON.stringify(obj),
                success: function (msg) {
                    oTable = $('#StockCountTable').DataTable();
                        oTable.draw();
                        $(""#msg"").html(msg);
                        $(""#modalHeader"").text(""Stock Count Processing"");
                        $(""#modalMessage"").text(msg);
                        $(""#myModal"").modal(""show"");
                    },
                    error: function () {
                        $(""#msg"").html(""Error while making Ajax call!"");
                        $(""#modalHeader"").text(""StockCount Processing"");
                        $(""#modalMessage"").text(msg);
                        $(""#myModal"").modal(""show"");
                    }
                });//ajax

        }
        
     
    </script>
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
#line 6 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\StockCount\StockCountSummary.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.StockCount.StockCountSummaryModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.StockCount.StockCountSummaryModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.StockCount.StockCountSummaryModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.StockCount.StockCountSummaryModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
