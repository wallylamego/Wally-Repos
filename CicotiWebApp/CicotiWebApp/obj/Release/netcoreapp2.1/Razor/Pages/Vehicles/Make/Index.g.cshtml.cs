#pragma checksum "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Make\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f707e1bc4aeb5eeda29628e5bab10513480d7832"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CicotiWebApp.Pages.Vehicles.Make.Pages_Vehicles_Make_Index), @"mvc.1.0.razor-page", @"/Pages/Vehicles/Make/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Vehicles/Make/Index.cshtml", typeof(CicotiWebApp.Pages.Vehicles.Make.Pages_Vehicles_Make_Index), null)]
namespace CicotiWebApp.Pages.Vehicles.Make
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f707e1bc4aeb5eeda29628e5bab10513480d7832", @"/Pages/Vehicles/Make/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ced8cd96f08a857c0609865a58388ea14041c11", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Vehicles_Make_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Make\Index.cshtml"
  
    Layout = "_LayoutDataTables";

#line default
#line hidden
            BeginContext(308, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Make\Index.cshtml"
  
    ViewData["Title"] = "Make: Listing";
    Layout = "~/Pages/_LayoutDataTables.cshtml";

#line default
#line hidden
            BeginContext(409, 36, true);
            WriteLiteral("\r\n<h2>Make Listing</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(445, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e21ebc24b46475d97b11ab89b4659dd", async() => {
                BeginContext(466, 10, true);
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
            BeginContext(480, 417, true);
            WriteLiteral(@"
</p>
<div id=""divMakeTable"" style=""width:90%; margin:0 auto;"">
    <table id=""MakeTable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>MakeID</th>
                <th>Make Name</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
    </table>
</div>

");
            EndContext();
            BeginContext(898, 40, false);
#line 37 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Make\Index.cshtml"
Write(await Html.PartialAsync("_ModalPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(938, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(960, 1007, true);
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(document).ready(function ()
        {
            $(""#MakeTable"").on('xhr.dt', function (e, settings, json, xhr) {
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

                    ""url"": ""/Vehicles/Make/Index?handler=Paging"",
                     ""headers"":
                        {
                            ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(1968, 25, false);
#line 63 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Make\Index.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(1993, 3342, true);
                WriteLiteral(@"'
                        },
                    ""type"": ""POST"",
                    /*""contentType"": ""application/x-www-form-urlencoded"",*/
                    ""datatype"": ""json""
                },
                ""columnDefs"":
                [   {
                        /*Make ID is not visible and is not searchable*/
                        ""targets"": [0],
                        ""visible"": false,
                        ""searchable"": true
                    },
                    {
                        /*Make Name is visible and is not searchable*/
                        ""targets"": [1],
                        ""visible"": true,
                        ""searchable"": true,
                        ""orderable"": true
                    },
                    {
                        /*Edit button  is  visible and is not searchable*/
                        ""targets"": [2],
                        ""visible"": true,
                        ""searchable"": false,
                     ");
                WriteLiteral(@"   ""orderable"": false
                    },
                    {
                        /*Delete button  is  visible and is not searchable*/
                        ""targets"": [3],
                        ""visible"": true,
                        ""searchable"": false,
                        ""orderable"": false
                    }
                ],
                ""columns"": [
                    { ""data"": ""id"", ""name"": ""id"", ""autoWidth"": true },
                    { ""data"": ""makeName"", ""name"": ""makeName"", ""autoWidth"": true },
                   {
                        ""render"": function (data, type, full, meta) {
                            return ""<p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' data-target='#edit' onclick='window.location.href=\""/Vehicles/Make/Edit/"" + full.id + ""\""\'><span class='glyphicon glyphicon-pencil'></span></button></p>"";
                        }
                    },
 ");
                WriteLiteral(@"                   {
                        ""data"": null, render: function (data, type, row)
                        {
                            return '<p data-placement=""top"" data-toggle=""tooltip"" title=""Delete""><button class=""btn btn-danger btn-xs"" data-title=""Delete"" data-toggle=""modal"" data-target=""#delete"" onclick=DeleteData(""' + row.id + '"")><span class=""glyphicon glyphicon-trash""></span></button></p>';
                       }
                    }
                ]

            });//Make Table
        });//Document Ready end.


    function DeleteData(MakeID)
     {
            if (confirm(""Are you sure you want to delete this Make ...?""))
            {
                console.log(""Make ID to be deleted is: "" + MakeID)
                Delete(MakeID);
            }
            else
            {
                return false;
            }
     }

        function Delete(MakeID)
        {
            console.log(""Before Ajax Call:"" + ""Make ID is: "" + MakeID)
            v");
                WriteLiteral(@"ar obj = {};
            obj.MakeID = MakeID;


            $.ajax({
                type: ""DELETE"",
                url: '/Vehicles/Make/Index?handler=Delete',
                headers:
                    {
                        ""RequestVerificationToken"": '");
                EndContext();
                BeginContext(5336, 25, false);
#line 143 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Make\Index.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
                EndContext();
                BeginContext(5361, 932, true);
                WriteLiteral(@"'
                    },
                contentType: ""application/json"",
                dataType: ""json"",
                data: JSON.stringify(obj),
                success: function (msg) {
                        oTable = $('#MakeTable').DataTable();
                        oTable.draw();
                        $(""#msg"").html(msg);
                        $(""#modalHeader"").text(""Make Processing Make"");
                        $(""#modalMessage"").text(msg);
                        $(""#myModal"").modal(""show"");
                    },
                    error: function () {
                        $(""#msg"").html(""Error while making Ajax call!"");
                        $(""#modalHeader"").text(""Make Processing Make"");
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
#line 6 "C:\Users\wallyf\source\repos\CicotiWebApp\CicotiWebApp\Pages\Vehicles\Make\Index.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CicotiWebApp.Pages.Vehicles.Make.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Vehicles.Make.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CicotiWebApp.Pages.Vehicles.Make.IndexModel>)PageContext?.ViewData;
        public CicotiWebApp.Pages.Vehicles.Make.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
