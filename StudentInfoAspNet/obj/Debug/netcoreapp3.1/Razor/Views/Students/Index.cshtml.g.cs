#pragma checksum "E:\Project\StudentInfoAspNet\StudentInfoAspNet\Views\Students\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4758b7132db8bb1c5b1b72de62dbcc3db235d0ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Students_Index), @"mvc.1.0.view", @"/Views/Students/Index.cshtml")]
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
#line 1 "E:\Project\StudentInfoAspNet\StudentInfoAspNet\Views\_ViewImports.cshtml"
using StudentInfoAspNet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Project\StudentInfoAspNet\StudentInfoAspNet\Views\_ViewImports.cshtml"
using StudentInfoAspNet.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4758b7132db8bb1c5b1b72de62dbcc3db235d0ea", @"/Views/Students/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9107729eb4a90e91235e9b2128c8f835df639c79", @"/Views/_ViewImports.cshtml")]
    public class Views_Students_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Project\StudentInfoAspNet\StudentInfoAspNet\Views\Students\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Students</h1>
<div>
    <input type=""text"" id=""name"" name=""name"" placeholder=""Enter the name""/>
    <input type=""text"" id=""secondName"" name=""secondName"" placeholder=""Enter second name""/>
    <input type=""text"" id=""lastName"" name=""lastName"" placeholder=""Enter last name""/> 
    <input type=""number"" id=""averageScore"" name=""averageScore"" placeholder=""Enter ball""/>
    <select id=""groupId"" name=""groupId""></select>
    <button type=""button"" id=""addStudentButton"">Add</button>
</div>
<div class=""d-table"">
    <table class=""table table-striped table-bordered table-hover d-table-row"">
        <thead>
        <tr>
            <th>Name</th>
            <th>Second Name</th>
            <th>Last Name</th>
            <th>Average Score</th>
            <th>Group</th>
        </tr>
        </thead>
        <tbody id=""students"">
        
        </tbody>
    </table>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
