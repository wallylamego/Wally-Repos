#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Fleet\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "617d71c9fbadfae6b095de08fac383cab4571b89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.Vehicles.Fleet.Pages_Vehicles_Fleet_Index), @"mvc.1.0.razor-page", @"/Pages/Vehicles/Fleet/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Vehicles/Fleet/Index.cshtml", typeof(CicotiWebApp.Pages.Vehicles.Fleet.Pages_Vehicles_Fleet_Index), null)]
namespace CicotiWebApp.Pages.Vehicles.Fleet
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"617d71c9fbadfae6b095de08fac383cab4571b89", @"/Pages/Vehicles/Fleet/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Vehicles_Fleet_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Fleet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Fleet\Index.cshtml"
  
    Layout = "_LayoutDataTables";

#line default
#line hidden
            BeginContext(309, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Fleet\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Pages/_LayoutDataTables.cshtml";

#line default
#line hidden
            BeginContext(402, 33, true);
            WriteLiteral("\r\n<h2>Own Fleet</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(435, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "baa71257cbfe4cfc8892907308e28b02", async() => {
                BeginContext(455, 6, true);
                WriteLiteral("Create");
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
            BeginContext(465, 932, true);
            WriteLiteral(@"
</p>
<div id=""divVehicleTable"" style=""width:90%; margin:0 auto;"">
    <table id=""VehicleTable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>VehicleID</th>
                <th>Vehicle Purpose</th>
                <th>Branch</th>
                <th>Cost Centre</th>
                <th>Registration Number</th>
                <th>Make</th>
                <th>Model</th>
                <th>Fuel Type</th>
                <th>Drive Type</th>
                <th>Tonnage</th>
                <th>Fixed Assets Number</th>
                <th>Acquisition Date</th>
                <th>Acquisition Cost</th>
                <th>Depreciation Months</th>
                <th>Employee</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
    </table>
</div>

");
            EndContext();
            BeginContext(1398, 40, false);
#line 50 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Fleet\Index.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(1438, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1460, 1014, true);
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(document).ready(function ()
        {
            $(""#VehicleTable"").on('xhr.dt', function (e, settings, json, xhr) {
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
                    ""url"": ""/Vehicles/Fleet/Index?handler=FleetPaging"",
                     ""headers"":
                        {
                            ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(2475, 25, false);
#line 75 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Fleet\Index.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(2500, 7712, true);
                WriteLiteral(@"'
                        },
                    ""type"": ""POST"",
                    /*""contentType"": ""application/x-www-form-urlencoded"",*/
                    ""datatype"": ""json""
                },
                ""columnDefs"":
                [   {
                        /*Vehicle ID is not visible and is not searchable*/
                        ""targets"": [0],
                        ""visible"": false,
                        ""searchable"": false
                    },
                    {
                        /*Vehicle Purpose  is visible and is searchable*/
                        ""targets"": [1],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Branch  is visible and is searchable*/
                        ""targets"": [2],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                       ");
                WriteLiteral(@" /*Cost Centre  is visible and is searchable*/
                        ""targets"": [3],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Registration Number is visible and is searchable*/
                        ""targets"": [4],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Make  is visible and is searchable*/
                        ""targets"": [5],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Model is visible and is searchable*/
                        ""targets"": [6],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Fuel Type is visible and is searchable*/
      ");
                WriteLiteral(@"                  ""targets"": [7],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Drive Type is visible and is searchable*/
                        ""targets"": [8],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Tonnage is visible and is searchable*/
                        ""targets"": [9],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Fixed Assets Register is visible and is searchable*/
                        ""targets"": [10],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Acquistion Date is visible and is searchable*/
                        ""targets"": [11],
  ");
                WriteLiteral(@"                      ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Acquistion Cost is visible and is searchable*/
                        ""targets"": [12],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Depreciation Months is visible and is searchable*/
                        ""targets"": [13],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Employee   is visible and is searchable*/
                        ""targets"": [14],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Edit button  is  visible and is not searchable*/
                        ""targets"": [15],
                        ""visi");
                WriteLiteral(@"ble"": true,
                        ""searchable"": false,
                        ""orderable"": false
                    },
                    {
                        /*Delete button  is  visible and is not searchable*/
                        ""targets"": [16],
                        ""visible"": true,
                        ""searchable"": false,
                        ""orderable"": false
                    }
                ],
                ""columns"": [
                    { ""data"": ""vehicleID"", ""name"": ""vehicleID"", ""autoWidth"": true },
                    { ""data"": ""purpose"", ""name"": ""purpose"", ""autoWidth"": true },
                    { ""data"": ""branch"", ""name"": ""branch"", ""autoWidth"": true },
                    { ""data"": ""costCentre"", ""name"": ""costCentre"", ""autoWidth"": true },
                    { ""data"": ""registrationNumber"", ""name"": ""registrationNumber"", ""autoWidth"": true },
                    { ""data"": ""make"", ""name"": ""make"", ""autoWidth"": true },
                    { ""data"": ""mo");
                WriteLiteral(@"del"", ""name"": ""model"", ""autoWidth"": true },
                    { ""data"": ""fuelType"", ""name"": ""fuelType"", ""autoWidth"": true },
                    { ""data"": ""driveType"", ""name"": ""driveType"", ""autoWidth"": true },
                    { ""data"": ""tonnage"", ""name"": ""tonnage"", ""autoWidth"": true },
                    { ""data"": ""fixedAssetsNumber"", ""name"": ""fixedAssetsNumber"", ""autoWidth"": true },
                    { ""data"": ""acquisitionDate"", ""name"": ""acquisitionDate"", ""autoWidth"": true },
                    { ""data"": ""acquisitionCost"", ""name"": ""acquisitionCost"", ""autoWidth"": true },
                    { ""data"": ""depreciationMonths"", ""name"": ""depreciationMonths"", ""autoWidth"": true },
                    { ""data"": ""employee"", ""name"": ""employee"", ""autoWidth"": true },
                    {
                        ""render"": function (data, type, full, meta) {
                            return ""<p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='E");
                WriteLiteral(@"dit' data-toggle='modal' data-target='#edit' onclick='window.location.href=\""/Vehicles/Fleet/Fleet/"" + full.vehicleID +  ""\""\'><span class='glyphicon glyphicon-pencil'></span></button></p>"";
                        }
                    },
                    {
                        ""data"": null, render: function (data, type, row)
                        {
                            return '<p data-placement=""top"" data-toggle=""tooltip"" title=""Delete""><button class=""btn btn-danger btn-xs"" data-title=""Delete"" data-toggle=""modal"" data-target=""#delete"" onclick=DeleteData(""' + row.vehicleID + '"")><span class=""glyphicon glyphicon-trash""></span></button></p>';
                       }
                    }
                ]

            });//Fleet Table
        });//Document Ready end.


    function DeleteData(VehicleID)
     {
            if (confirm(""Are you sure you want to delete this Vehicle ...?""))
            {
                console.log(""Vehicle ID to be deleted is: "" + VehicleID)
  ");
                WriteLiteral(@"              Delete(VehicleID);
            }
            else
            {
                return false;
            }
     }

        function Delete(VehicleID)
        {
            console.log(""Before Ajax Call:"" + ""Vehicle ID is: "" + VehicleID)
            var obj = {};
            obj.VehicleID = VehicleID;


            $.ajax({
                type: ""DELETE"",
                url: '/Fleet/Index?handler=Delete',
                headers:
                    {
                        ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(10213, 25, false);
#line 245 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Fleet\Index.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(10238, 937, true);
                WriteLiteral(@"'
                    },
                contentType: ""application/json"",
                dataType: ""json"",
                data: JSON.stringify(obj),
                success: function (msg) {
                    oTable = $('#VehicleTable').DataTable();
                        oTable.draw();
                        $(""#msg"").html(msg);
                        $(""#modalHeader"").text(""Fleet Processing Status"");
                        $(""#modalMessage"").text(msg);
                        $(""#myModal"").modal(""show"");
                    },
                    error: function () {
                        $(""#msg"").html(""Error while making Ajax call!"");
                        $(""#modalHeader"").text(""Fleet Processing Status"");
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
#line 6 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Fleet\Index.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.Vehicles.Fleet.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Vehicles.Fleet.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Vehicles.Fleet.IndexModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.Vehicles.Fleet.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
