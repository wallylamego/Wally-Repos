#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\InsuranceType\InsuranceType.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc2771b9eb736196db11cee3363481ee0e6a9ca7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.ABC.InsuranceType.Pages_ABC_InsuranceType_InsuranceType), @"mvc.1.0.razor-page", @"/Pages/ABC/InsuranceType/InsuranceType.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/ABC/InsuranceType/InsuranceType.cshtml", typeof(CicotiWebApp.Pages.ABC.InsuranceType.Pages_ABC_InsuranceType_InsuranceType), null)]
namespace CicotiWebApp.Pages.ABC.InsuranceType
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc2771b9eb736196db11cee3363481ee0e6a9ca7", @"/Pages/ABC/InsuranceType/InsuranceType.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ABC_InsuranceType_InsuranceType : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "InsuranceTypeItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\InsuranceType\InsuranceType.cshtml"
  
    Layout = "_LayoutDataTables";

#line default
#line hidden
            BeginContext(325, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\InsuranceType\InsuranceType.cshtml"
  
    ViewData["Title"] = "Insurance Type Listing";

#line default
#line hidden
            BeginContext(385, 46, true);
            WriteLiteral("\r\n<h2>Insurance Type Listing</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(431, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ede64651b1474e2395f388ed7c5d08f5", async() => {
                BeginContext(463, 10, true);
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
            BeginContext(477, 535, true);
            WriteLiteral(@"
</p>
<div id=""divInsuranceTypeTable"" style=""width:90%; margin:0 auto;"">
    <table id=""InsuranceTypeTable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>ID</th>
                <th>Insurance</th>
                <th>Cost Driver</th>
                <th>Period</th>
                <th>Amount</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
    </table>
</div>

");
            EndContext();
            BeginContext(1013, 40, false);
#line 39 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\InsuranceType\InsuranceType.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(1053, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1077, 1028, true);
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(document).ready(function ()
        {
            $(""#InsuranceTypeTable"").on('xhr.dt', function (e, settings, json, xhr) {
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

                    ""url"": ""/ABC/InsuranceType/InsuranceType?handler=Paging"",
                     ""headers"":
                        {
                            ""RequestVerificationToken");
                WriteLiteral("\": \'");
                EndContext();
                BeginContext(2106, 25, false);
#line 66 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\InsuranceType\InsuranceType.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(2131, 4415, true);
                WriteLiteral(@"'
                        },
                    ""type"": ""POST"",
                    /*""contentType"": ""application/x-www-form-urlencoded"",*/
                    ""datatype"": ""json""
                },
                ""columnDefs"":
                [
                    {
                        /*ID is not visible and is not searchable*/
                        ""targets"": [0],
                        ""visible"": false,
                        ""searchable"": false
                    },
                    {
                        /*Insurance is visible and is searchable*/
                        ""targets"": [1],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Cost Driver is visible and is not searchable*/
                        ""targets"": [2],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
           ");
                WriteLiteral(@"             /*Period is  visible and is  searchable*/
                        ""targets"": [3],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Amount   is  visible and is  searchable*/
                        ""targets"": [4],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Edit button  is  visible and is not searchable*/
                        ""targets"": [5],
                        ""visible"": true,
                        ""searchable"": false,
                        ""orderable"": false
                    },
                    {
                        /*Delete button  is  visible and is not searchable*/
                        ""targets"": [6],
                        ""visible"": true,
                        ""searchable"": false,
                        ""orderable"": false
    ");
                WriteLiteral(@"                }
                ],
                ""columns"": [
                    { ""data"": ""actCostInsuranceTypeID"", ""name"": ""actCostInsuranceTypeID"", ""autoWidth"": true },
                    { ""data"": ""insurance"", ""name"": ""insurance"", ""autoWidth"": true },
                    { ""data"": ""costDriver"", ""name"": ""costDriver"", ""autoWidth"": true },
                    { ""data"": ""period"", ""name"": ""period"", ""autoWidth"": true },
                    { ""data"": ""amount"", ""name"": ""amount"", ""autoWidth"": true },
                    {
                        ""render"": function (data, type, full, meta) {
                            return ""<p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' data-target='#edit' onclick='window.location.href=\""/ABC/InsuranceType/InsuranceTypeItem/"" + full.actCostInsuranceTypeID +  ""\""\'><span class='glyphicon glyphicon-pencil'></span></button></p>"";
                        }
                    }");
                WriteLiteral(@",
                    {
                        ""data"": null, render: function (data, type, row)
                        {
                            return '<p data-placement=""top"" data-toggle=""tooltip"" title=""Delete""><button class=""btn btn-danger btn-xs"" data-title=""Delete"" data-toggle=""modal"" data-target=""#delete"" onclick=DeleteData(""' + row.actCostInsuranceTypeID + '"")><span class=""glyphicon glyphicon-trash""></span></button></p>';
                       }
                    }
                ]

            });//Insurance Table
        });//Document Ready end.


    function DeleteData(ID)
     {
            if (confirm(""Are you sure you want to delete this Insurance Item ...?""))
            {
                console.log(""Insurance ID to be deleted is: "" + ID)
                Delete(ID);
            }
            else
            {
                return false;
            }
     }

        function Delete(ID)
        {
        console.log(""Before Ajax Call:"" + ""Insurance ID i");
                WriteLiteral(@"s: "" + ID)
            var obj = {};
            obj.actCostInsuranceTypeID = ID;


            $.ajax({
                type: ""DELETE"",
                url: '/ABC/InsuranceType/InsuranceType?handler=Delete',
                headers:
                    {
                        ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(6547, 25, false);
#line 167 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\InsuranceType\InsuranceType.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(6572, 955, true);
                WriteLiteral(@"'
                    },
                contentType: ""application/json"",
                dataType: ""json"",
                data: JSON.stringify(obj),
                success: function (msg) {
                        oTable = $('#InsuranceTypeTable').DataTable();
                        oTable.draw();
                        $(""#msg"").html(msg);
                        $(""#modalHeader"").text(""Insurance Processing Status"");
                        $(""#modalMessage"").text(msg);
                        $(""#myModal"").modal(""show"");
                    },
                    error: function () {
                        $(""#msg"").html(""Error while making Ajax call!"");
                        $(""#modalHeader"").text(""Insurance Processing Status"");
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
#line 6 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\InsuranceType\InsuranceType.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.ABC.InsuranceType.InsuranceTypeTableModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.ABC.InsuranceType.InsuranceTypeTableModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.ABC.InsuranceType.InsuranceTypeTableModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.ABC.InsuranceType.InsuranceTypeTableModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
