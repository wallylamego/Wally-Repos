#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AccountMovement\AccountMovTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9ffb9276afd5639ce1de7e754befc5c9fa90231"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.ABC.AccountMovement.Pages_ABC_AccountMovement_AccountMovTable), @"mvc.1.0.razor-page", @"/Pages/ABC/AccountMovement/AccountMovTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/ABC/AccountMovement/AccountMovTable.cshtml", typeof(CicotiWebApp.Pages.ABC.AccountMovement.Pages_ABC_AccountMovement_AccountMovTable), null)]
namespace CicotiWebApp.Pages.ABC.AccountMovement
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9ffb9276afd5639ce1de7e754befc5c9fa90231", @"/Pages/ABC/AccountMovement/AccountMovTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ABC_AccountMovement_AccountMovTable : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AccountMovement\AccountMovTable.cshtml"
  
    Layout = "_LayoutDataTables";

#line default
#line hidden
            BeginContext(324, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AccountMovement\AccountMovTable.cshtml"
  
    ViewData["Title"] = "ABC: Account Movement Table";

#line default
#line hidden
            BeginContext(389, 800, true);
            WriteLiteral(@"
<h2>Account Balance Listing</h2>

<p>
</p>
<div id=""divAccountMovTable"" style=""width:90%; margin:0 auto;"">
    <table id=""AccountMovTable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>AccountID</th>
                <th>Account No</th>
                <th>Account Name</th>
                <th>Period No</th>
                <th>Movement</th>
                <th>YTD</th>
                <th>Branch</th>
                <th>Category</th>
                <th>Sub Category</th>
                <th>CostDriver</th>
                <th>AllocationSplit</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
    </table>
</div>

");
            EndContext();
            BeginContext(1190, 40, false);
#line 44 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AccountMovement\AccountMovTable.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(1230, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1254, 1029, true);
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(document).ready(function ()
        {
            $(""#AccountMovTable"").on('xhr.dt', function (e, settings, json, xhr) {
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

                    ""url"": ""/ABC/AccountMovement/AccountMovTable?handler=Paging"",
                     ""headers"":
                        {
                            ""RequestVerificationToke");
                WriteLiteral("n\": \'");
                EndContext();
                BeginContext(2284, 25, false);
#line 71 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AccountMovement\AccountMovTable.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(2309, 6879, true);
                WriteLiteral(@"'
                        },
                    ""type"": ""POST"",
                    /*""contentType"": ""application/x-www-form-urlencoded"",*/
                    ""datatype"": ""json""
                },
                ""columnDefs"":
                    [
                    {
                        /*Account ID is not visible and is searchable*/
                        ""targets"": [0],
                        ""visible"": false,
                        ""searchable"": false
                    },
                    {
                        /*Account Number is  visible and is searchable*/
                        ""targets"": [1],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*accountName is visible and is searchable*/
                        ""targets"": [2],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
 ");
                WriteLiteral(@"                       /*PeriodNo is visible and is searchable*/
                        ""targets"": [3],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Movement is visible and is searchable*/
                        ""targets"": [4],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*YTD is visible and is searchable*/
                        ""targets"": [5],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*branch is visible and is searchable*/
                        ""targets"": [6],
                        ""visible"": true,
                        ""searchable"": true
                        },
                        {
                            /*Category is visible and is sea");
                WriteLiteral(@"rchable*/
                            ""targets"": [7],
                            ""visible"": true,
                            ""searchable"": true
                        },
                        {
                            /*Sub Category is visible and is searchable*/
                            ""targets"": [8],
                            ""visible"": true,
                            ""searchable"": true
                        },
                        {
                            /*Cost Driver is visible and is searchable*/
                            ""targets"": [9],
                            ""visible"": true,
                            ""searchable"": true
                        },
                        {
                            /*Allocation Split is visible and is  searchable*/
                            ""targets"": [10],
                            ""visible"": true,
                            ""searchable"": true
                        },
                    {
           ");
                WriteLiteral(@"             /*Edit button  is  visible and is not searchable*/
                        ""targets"": [11],
                        ""visible"": true,
                        ""searchable"": false,
                        ""orderable"": false
                    },
                    {
                        /*Delete button  is  visible and is not searchable*/
                        ""targets"": [12],
                        ""visible"": true,
                        ""searchable"": false,
                        ""orderable"": false
                    }
                ],
                ""columns"": [
                    { ""data"": ""actCostAccountID"", ""name"": ""actCostAccountID"", ""autoWidth"": true },
                    { ""data"": ""accountNo"", ""name"": ""accountNo"", ""autoWidth"": true },
                    { ""data"": ""accountName"", ""name"": ""accountName"", ""autoWidth"": true },
                    { ""data"": ""periodNo"", ""name"": ""periodNo"", ""autoWidth"": true },
                    {
                        ""rende");
                WriteLiteral(@"r"": function (data, type, full, meta) {
                            return FormatToDecimal(full.movement);
                        }
                    },
                    {
                        ""render"": function (data, type, full, meta) {
                            return FormatToDecimal(full.ytd);
                        }
                    },
                    //{ ""data"": ""movement"", ""name"": ""movement"", ""autoWidth"": true },
                    //{ ""data"": ""ytd"", ""name"": ""ytd"", ""autoWidth"": true },
                    { ""data"": ""branch"", ""name"": ""branch"", ""autoWidth"": true },
                    { ""data"": ""category"", ""name"": ""category"", ""autoWidth"": true },
                    { ""data"": ""subCategory"", ""name"": ""subCategory"", ""autoWidth"": true },
                    { ""data"": ""costDriver"", ""name"": ""costDriver"", ""autoWidth"": true },
                    { ""data"": ""allocationSplit"", ""name"": ""allocationSplit"", ""autoWidth"": true },
                    {
                        ""render");
                WriteLiteral(@""": function (data, type, full, meta) {
                            return ""<p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' data-target='#edit' onclick='window.location.href=\""/ABC/Accounts/Account/"" + full.actCostAccountID +  ""\""\'><span class='glyphicon glyphicon-pencil'></span></button></p>"";
                        }
                    },
                    {
                        ""data"": null, render: function (data, type, row)
                        {
                            return '<p data-placement=""top"" data-toggle=""tooltip"" title=""Delete""><button class=""btn btn-danger btn-xs"" data-title=""Delete"" data-toggle=""modal"" data-target=""#delete"" onclick=DeleteData(""' + row.actCostAccountID + '"")><span class=""glyphicon glyphicon-trash""></span></button></p>';
                       }
                    }
                ]

            });//Accounts Table
        });//Document Ready end.


    functi");
                WriteLiteral(@"on DeleteData(ID)
     {
            if (confirm(""Are you sure you want to delete this Account Movement ...?""))
            {
                console.log("" ID to be deleted is: "" + ID)
                Delete(ID);
            }
            else
            {
                return false;
            }
     }

        function Delete(ID)
        {
        console.log(""Before Ajax Call:"" + ""Account ID is: "" + ID)
            var obj = {};
            obj.actCostAccountID = ID;


            $.ajax({
                type: ""DELETE"",
                url: '/ABC/AccountMovement/AccountMovTable?handler=Delete',
                headers:
                    {
                        ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(9189, 25, false);
#line 224 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AccountMovement\AccountMovTable.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(9214, 956, true);
                WriteLiteral(@"'
                    },
                contentType: ""application/json"",
                dataType: ""json"",
                data: JSON.stringify(obj),
                success: function (msg) {
                        oTable = $('#AccountMovTable').DataTable();
                        oTable.draw();
                        $(""#msg"").html(msg);
                        $(""#modalHeader"").text(""Account Movement Processing Status"");
                        $(""#modalMessage"").text(msg);
                        $(""#myModal"").modal(""show"");
                    },
                    error: function () {
                        $(""#msg"").html(""Error while making Ajax call!"");
                        $(""#modalHeader"").text(""Account Movement Processing Status"");
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
#line 6 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\ABC\AccountMovement\AccountMovTable.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.ABC.AccountMovement.AccountMovTableModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.ABC.AccountMovement.AccountMovTableModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.ABC.AccountMovement.AccountMovTableModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.ABC.AccountMovement.AccountMovTableModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
