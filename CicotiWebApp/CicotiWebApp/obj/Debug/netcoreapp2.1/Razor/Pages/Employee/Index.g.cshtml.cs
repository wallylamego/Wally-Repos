#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Employee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d1dc73a0ddb855ffef61621c27ea3e7f4a11e04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.Employee.Pages_Employee_Index), @"mvc.1.0.razor-page", @"/Pages/Employee/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Employee/Index.cshtml", typeof(CicotiWebApp.Pages.Employee.Pages_Employee_Index), null)]
namespace CicotiWebApp.Pages.Employee
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d1dc73a0ddb855ffef61621c27ea3e7f4a11e04", @"/Pages/Employee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Employee_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Employee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Employee\Index.cshtml"
  
    Layout = "_LayoutDataTables";

#line default
#line hidden
            BeginContext(303, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Employee\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Pages/_LayoutDataTables.cshtml";

#line default
#line hidden
            BeginContext(396, 33, true);
            WriteLiteral("\r\n<h2>Employees</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(429, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc8180ef8bee41fcbc5f046f76050d85", async() => {
                BeginContext(452, 10, true);
                WriteLiteral("Update/New");
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
            BeginContext(466, 686, true);
            WriteLiteral(@"
</p>
<div id=""divEmployeeTable"" style=""width:90%; margin:0 auto;"">
    <table id=""EmployeeTable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>EmployeeID</th>
                <th>Employee No</th>
                <th>Name</th>
                <th>Job Description</th>
                <th>Reports To</th>
                <th>Department</th>
                <th>Cost Centre</th>
                <th>Branch</th>
                <th>Start Date</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
    </table>
</div>

");
            EndContext();
            BeginContext(1153, 40, false);
#line 44 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Employee\Index.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(1193, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1215, 1004, true);
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(document).ready(function ()
        {
            $(""#EmployeeTable"").on('xhr.dt', function (e, settings, json, xhr) {
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
                    ""url"": ""/Employee/Index?handler=Paging"",
                     ""headers"":
                        {
                            ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(2220, 25, false);
#line 69 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Employee\Index.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(2245, 5719, true);
                WriteLiteral(@"'
                        },
                    ""type"": ""POST"",
                    /*""contentType"": ""application/x-www-form-urlencoded"",*/
                    ""datatype"": ""json""
                },
                ""columnDefs"":
                [   {
                        /*Employee ID is not visible and is not searchable*/
                        ""targets"": [0],
                        ""visible"": false,
                        ""searchable"": false
                    },
                    {
                        /*Employee No  is visible and is searchable*/
                        ""targets"": [1],
                        ""visible"": true,
                        ""searchable"": true
                        },
                       
                    {
                        /*Employee Name  is visible and is searchable*/
                        ""targets"": [2],
                        ""visible"": true,
                        ""searchable"": true
                    },
             ");
                WriteLiteral(@"       {
                        /*Job Description  is visible and is searchable*/
                        ""targets"": [3],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Reports To  is visible and is searchable*/
                        ""targets"": [4],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Department  is visible and is searchable*/
                        ""targets"": [5],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Cost Centre  is visible and is searchable*/
                        ""targets"": [5],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Branch");
                WriteLiteral(@"  is visible and is searchable*/
                        ""targets"": [6],
                        ""visible"": true,
                        ""searchable"": true
                    },
                    {
                        /*Start Date is visible and is searchable*/
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
   ");
                WriteLiteral(@"                 ],
                ""columns"": [
                    { ""data"": ""employeeID"", ""name"": ""employeeID"", ""autoWidth"": true },
                    { ""data"": ""employeeNo"", ""name"": ""employeeNo"", ""autoWidth"": true },
                    { ""data"": ""name"", ""name"": ""name"", ""autoWidth"": true },
                    { ""data"": ""jobDescription"", ""name"": ""jobDescription"", ""autoWidth"": true },
                    { ""data"": ""reportTo"", ""name"": ""reportTo"", ""autoWidth"": true },
                    { ""data"": ""department"", ""name"": ""department"", ""autoWidth"": true },
                    { ""data"": ""costCentre"", ""name"": ""costCentre"", ""autoWidth"": true },
                    { ""data"": ""branch"", ""name"": ""branch"", ""autoWidth"": true },
                    { ""data"": ""startDate"", ""name"": ""startDate"", ""autoWidth"": true },
                    {
                        ""render"": function (data, type, full, meta) {
                            return ""<p data-placement='top' data-toggle='tooltip' title='Edit'><button cl");
                WriteLiteral(@"ass='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' data-target='#edit' onclick='window.location.href=\""/Employee/Employee/"" + full.employeeID +  ""\""\'><span class='glyphicon glyphicon-pencil'></span></button></p>"";
                        }
                    },
                    {
                        ""data"": null, render: function (data, type, row)
                        {
                            return '<p data-placement=""top"" data-toggle=""tooltip"" title=""Delete""><button class=""btn btn-danger btn-xs"" data-title=""Delete"" data-toggle=""modal"" data-target=""#delete"" onclick=DeleteData(""' + row.employeeID + '"")><span class=""glyphicon glyphicon-trash""></span></button></p>';
                       }
                    }
                ]

            });//Employee Table
        });//Document Ready end.


    function DeleteData(EmployeeID)
     {
            if (confirm(""Are you sure you want to delete this Employee ...?""))
            {
                console.log(""E");
                WriteLiteral(@"mployee ID to be deleted is: "" + Employee)
                Delete(EmployeeID);
            }
            else
            {
                return false;
            }
     }

        function Delete(EmployeeID)
        {
            console.log(""Before Ajax Call:"" + ""Employee ID is: "" + EmployeeID)
            var obj = {};
            obj.EmployeeID = EmployeeID;


            $.ajax({
                type: ""DELETE"",
                url: '/Employee/Index?handler=Delete',
                headers:
                    {
                        ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(7965, 25, false);
#line 198 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Employee\Index.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(7990, 940, true);
                WriteLiteral(@"'
                    },
                contentType: ""application/json"",
                dataType: ""json"",
                data: JSON.stringify(obj),
                success: function (msg) {
                    oTable = $('#EmployeeTable').DataTable();
                        oTable.draw();
                        $(""#msg"").html(msg);
                        $(""#modalHeader"").text(""Employee Processing Status"");
                        $(""#modalMessage"").text(msg);
                        $(""#myModal"").modal(""show"");
                    },
                    error: function () {
                        $(""#msg"").html(""Error while making Ajax call!"");
                        $(""#modalHeader"").text(""Employee Processing Status"");
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
#line 6 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Employee\Index.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.Employee.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Employee.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Employee.IndexModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.Employee.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
