#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AllocationPerAccount\AllocationPerAccountTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68aa8f64d5e41ed1917e4394454878100f2adfb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.ABC.AllocationPerAccount.Pages_ABC_AllocationPerAccount_AllocationPerAccountTable), @"mvc.1.0.razor-page", @"/Pages/ABC/AllocationPerAccount/AllocationPerAccountTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/ABC/AllocationPerAccount/AllocationPerAccountTable.cshtml", typeof(CicotiWebApp.Pages.ABC.AllocationPerAccount.Pages_ABC_AllocationPerAccount_AllocationPerAccountTable), null)]
namespace CicotiWebApp.Pages.ABC.AllocationPerAccount
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68aa8f64d5e41ed1917e4394454878100f2adfb8", @"/Pages/ABC/AllocationPerAccount/AllocationPerAccountTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ABC_AllocationPerAccount_AllocationPerAccountTable : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "AllocationPerAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AllocationPerAccount\AllocationPerAccountTable.cshtml"
  
    Layout = "_LayoutDataTables";

#line default
#line hidden
            BeginContext(339, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AllocationPerAccount\AllocationPerAccountTable.cshtml"
  
    ViewData["Title"] = "ABC: Alloccation Per Account Listing";

#line default
#line hidden
            BeginContext(413, 54, true);
            WriteLiteral("\r\n<h2>Allocation Per Account Listing</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(467, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b81d4833bafe4761b91b6a5d39ddad99", async() => {
                BeginContext(502, 10, true);
                WriteLiteral("Create New");
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
            BeginContext(516, 678, true);
            WriteLiteral(@"
</p>
<div id=""divAccountTable"" style=""width:90%; margin:0 auto;"">
    <table id=""AccountTable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>ActCostAccountPerPrincipleID</th>
                <th>Account No</th>
                <th>AccountName</th>
                <th>Period</th>
                <th>CostDriver</th>
                <th>CostAllocationSplit</th>
                <th>AllocAccountPerc</th>
                <th>Comments</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
    </table>
</div>

");
            EndContext();
            BeginContext(1195, 40, false);
#line 42 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AllocationPerAccount\AllocationPerAccountTable.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(1235, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1259, 1041, true);
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(document).ready(function ()
        {
            $(""#AccountTable"").on('xhr.dt', function (e, settings, json, xhr) {
            }).DataTable({
                lengthMenu: [25, 100, 150, 200],
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

                    ""url"": ""/ABC/AllocationPerAccount/AllocationPerAccountTable?handler=Paging"",
                     ""headers"":
                        {
                            ""RequestVeri");
                WriteLiteral("ficationToken\": \'");
                EndContext();
                BeginContext(2301, 25, false);
#line 69 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AllocationPerAccount\AllocationPerAccountTable.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(2326, 5536, true);
                WriteLiteral(@"'
                        },
                    ""type"": ""POST"",
                    /*""contentType"": ""application/x-www-form-urlencoded"",*/
                    ""datatype"": ""json""
                },
                ""columnDefs"":
                    [
                    {
                        /*ActCostAccountPerPrincipleID ID is not visible and is searchable*/
                        ""targets"": [0],
                        ""visible"": false,
                        ""searchable"": false
                    },
                    {
                        /*Account No is  visible and is searchable*/
                        ""targets"": [1],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*AccountName is visible and is searchable*/
                        ""targets"": [2],
                        ""visible"": true,
                        ""searchable"": true
                    },
       ");
                WriteLiteral(@"             {
                        /*Period is visible and is searchable*/
                        ""targets"": [3],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*CostDriver is visible and is searchable*/
                        ""targets"": [4],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*CostAllocationSplit is visible and is searchable*/
                        ""targets"": [5],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*AllocAccountPerc is visible and is searchable*/
                        ""targets"": [6],
                        ""visible"": true,
                        ""searchable"": false
                    },
                    {
                        ");
                WriteLiteral(@"/*Comments is visible and is searchable*/
                        ""targets"": [7],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Edit button  is  visible and is not searchable*/
                        ""targets"": [8],
                        ""visible"": true,
                        ""searchable"": false,
                        ""orderable"": false
                    },
                    {
                        /*Delete button  is  visible and is not searchable*/
                        ""targets"": [9],
                        ""visible"": true,
                        ""searchable"": false,
                        ""orderable"": false
                    }
                ],
                ""columns"": [
                    { ""data"": ""actCostAccountPerPrincipleID"", ""name"": ""actCostAccountPerPrincipleID"", ""autoWidth"": true },
                    { ""data"": ""accountNo"", ""name"": ""accountNo"",");
                WriteLiteral(@" ""autoWidth"": true },
                    { ""data"": ""accountName"", ""name"": ""accountName"", ""autoWidth"": true },
                    { ""data"": ""period"", ""name"": ""period"", ""autoWidth"": true },
                    { ""data"": ""costDriver"", ""name"": ""costDriver"", ""autoWidth"": true },
                    { ""data"": ""costAllocationSplit"", ""name"": ""costAllocationSplit"", ""autoWidth"": true },
                    { ""data"": ""allocAccountPerc"", ""name"": ""allocAccountPerc"", ""autoWidth"": true },
                    { ""data"": ""comments"", ""name"": ""comments"", ""autoWidth"": true },
                    {
                        ""render"": function (data, type, full, meta) {
                            return ""<p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' data-target='#edit' onclick='window.location.href=\""/ABC/AllocationPerAccount/AllocationPerAccount/"" + full.actCostAccountPerPrincipleID +  ""\""\'><span class='glyphicon glyphicon-pencil'>");
                WriteLiteral(@"</span></button></p>"";
                        }
                    },
                    {
                        ""data"": null, render: function (data, type, row)
                        {
                            return '<p data-placement=""top"" data-toggle=""tooltip"" title=""Delete""><button class=""btn btn-danger btn-xs"" data-title=""Delete"" data-toggle=""modal"" data-target=""#delete"" onclick=DeleteData(""' + row.actCostAccountPerPrincipleID + '"")><span class=""glyphicon glyphicon-trash""></span></button></p>';
                       }
                    }
                ]

            });//Accounts Table
        });//Document Ready end.


    function DeleteData(ID)
     {
            if (confirm(""Are you sure you want to delete this Account Allocation Per Principle ...?""))
            {
                console.log("" ID to be deleted is: "" + ID)
                Delete(ID);
            }
            else
            {
                return false;
            }
     }

        fun");
                WriteLiteral(@"ction Delete(ID)
        {
        console.log(""Before Ajax Call:"" + ""Account ID is: "" + ID)
            var obj = {};
            obj.actCostAccountID = ID;


            $.ajax({
                type: ""DELETE"",
                url: '/ABC/AllocationPerAccount/AllocationPerAccountTable?handler=Delete',
                headers:
                    {
                        ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(7863, 25, false);
#line 191 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AllocationPerAccount\AllocationPerAccountTable.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(7888, 945, true);
                WriteLiteral(@"'
                    },
                contentType: ""application/json"",
                dataType: ""json"",
                data: JSON.stringify(obj),
                success: function (msg) {
                        oTable = $('#AccountTable').DataTable();
                        oTable.draw();
                        $(""#msg"").html(msg);
                        $(""#modalHeader"").text(""Account Processing Status"");
                        $(""#modalMessage"").text(msg);
                        $(""#myModal"").modal(""show"");
                    },
                    error: function () {
                        $(""#msg"").html(""Error while making Ajax call!"");
                        $(""#modalHeader"").text(""Account Processing Status"");
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
#line 6 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AllocationPerAccount\AllocationPerAccountTable.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.ABC.AllocationPerAccount.AllocationPerAccountTableModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.ABC.AllocationPerAccount.AllocationPerAccountTableModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.ABC.AllocationPerAccount.AllocationPerAccountTableModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.ABC.AllocationPerAccount.AllocationPerAccountTableModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
