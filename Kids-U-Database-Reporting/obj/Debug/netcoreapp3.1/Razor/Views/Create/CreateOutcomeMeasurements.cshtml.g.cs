#pragma checksum "D:\Kids-U-Database-Reporting\Kids-U-Database-Reporting\Views\Create\CreateOutcomeMeasurements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c59b91f1679423dda01e40a889202ec1702925ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Create_CreateOutcomeMeasurements), @"mvc.1.0.view", @"/Views/Create/CreateOutcomeMeasurements.cshtml")]
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
#line 1 "D:\Kids-U-Database-Reporting\Kids-U-Database-Reporting\Views\_ViewImports.cshtml"
using Kids_U_Database_Reporting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Kids-U-Database-Reporting\Kids-U-Database-Reporting\Views\_ViewImports.cshtml"
using Kids_U_Database_Reporting.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c59b91f1679423dda01e40a889202ec1702925ae", @"/Views/Create/CreateOutcomeMeasurements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2729ac36731c414e9ee10976a21255d520e94cf9", @"/Views/_ViewImports.cshtml")]
    public class Views_Create_CreateOutcomeMeasurements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/OutcomeMeasurements/Create"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59b91f1679423dda01e40a889202ec1702925ae4577", async() => {
                WriteLiteral("\n    \r\n    <div class=\"container body-content\">\r\n        <h2>Outcome Measurements</h2>\r\n\r\n        <!--form-->\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59b91f1679423dda01e40a889202ec1702925ae4963", async() => {
                    WriteLiteral(@"
            <div class=""form-horizontal"">
                <h4>Create New</h4><hr/>

                <!--student-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""StudentId"">Student</label>
                    <div class=""col-md-10"">
                        <select class=""form-control"" id=""StudentId"" name=""StudentId"">
                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59b91f1679423dda01e40a889202ec1702925ae5656", async() => {
                        WriteLiteral("Choose a name");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59b91f1679423dda01e40a889202ec1702925ae6978", async() => {
                        WriteLiteral("Generate at Runtime");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral(@"
                        </select>
                    </div>
                </div>

                <!--year-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""SchoolYearId"">School Year</label>
                    <div class=""col-md-10"">
                        <select class=""form-control"" id=""SchoolYearId"" name=""SchoolYearId""></select>
                    </div>
                </div>

                <!--premath-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""MathPreTest"">Math Pre-Test</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""MathPreTest"" name=""MathPreTest"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 1512, "\"", 1520, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--postmath-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""MathPostTest"">Math Post-Test</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""MathPostTest"" name=""MathPostTest"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 1924, "\"", 1932, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--prelanguage-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""LanguagePreTest"">Language Pre-Test</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""LanguagePreTest"" name=""LanguagePreTest"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 2351, "\"", 2359, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--postlanguage-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""LanguagePostTest"">Language Post-Test</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""LanguagePostTest"" name=""LanguagePostTest"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 2783, "\"", 2791, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--prereading-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""ReadingPreTest"">Reading Pre-Test</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""ReadingPreTest"" name=""ReadingPreTest"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 3205, "\"", 3213, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--postreading-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""ReadingPostTest"">Reading Post-Test</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""ReadingPostTest"" name=""ReadingPostTest"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 3632, "\"", 3640, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--fluency1-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""ReadingFluencyTest1"">Reading Fluency Test 1</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""ReadingFluencyTest1"" name=""ReadingFluencyTest1"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 4073, "\"", 4081, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--fluency2-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""ReadingFluencyTest2"">Reading Fluency Test 2</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""ReadingFluencyTest2"" name=""ReadingFluencyTest2"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 4514, "\"", 4522, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--fluency3-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""ReadingFluencyTest3"">Reading Fluency Test 3</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""ReadingFluencyTest3"" name=""ReadingFluencyTest3"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 4955, "\"", 4963, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--preesteem-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""EsteemPreTest"">Self-Esteem Pre-Test</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""EsteemPreTest"" name=""EsteemPreTest"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 5377, "\"", 5385, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--postesteem-->
                <div class=""form-group"">
                    <label class=""control-label col-md-2"" for=""EsteemPostTest"">Self-Esteem Post-Test</label>
                    <div class=""col-md-10"">
                        <input class=""form-control text-box single-line"" id=""EsteemPostTest"" name=""EsteemPostTest"" type=""number""");
                    BeginWriteAttribute("value", " value=\"", 5804, "\"", 5812, 0);
                    EndWriteAttribute();
                    WriteLiteral(@"/>
                    </div>
                </div>

                <!--submit-->
                <div class=""form-group"">
                    <div class=""col-md-offset-2 col-md-10"">
                        <input type=""submit"" value=""Create"" class=""btn btn-default"" />
                    </div>
                </div>
            </div>
        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n        <!--back-->\r\n        <div>\r\n            ");
#nullable restore
#line 130 "D:\Kids-U-Database-Reporting\Kids-U-Database-Reporting\Views\Create\CreateOutcomeMeasurements.cshtml"
       Write(Html.ActionLink("Back to List", "OutcomeMeasurements", "Data"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n     </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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