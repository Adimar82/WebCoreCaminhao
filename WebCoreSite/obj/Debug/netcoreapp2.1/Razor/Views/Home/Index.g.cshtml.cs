#pragma checksum "C:\Users\Adimar\source\repos\WebCore\WebCoreSite\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d183c99df7f1e455823c7e146c82b788e1f40e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d183c99df7f1e455823c7e146c82b788e1f40e5", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebCoreSite.Models.SPAObjetoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Adimar\source\repos\WebCore\WebCoreSite\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(91, 361, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-9"">
        <div id=""default"">
            <div class=""card mb-4"">
                <div class=""card-header"">Inserir ou Atualizar:</div>
                <div class=""card-body"">
                    <div class=""sbp-preview"">
                        <div class=""sbp-preview-content"">
                            
");
            EndContext();
#line 15 "C:\Users\Adimar\source\repos\WebCore\WebCoreSite\Views\Home\Index.cshtml"
                             if(string.IsNullOrEmpty(Model.MensagensErro) == false)
                            {

#line default
#line hidden
            BeginContext(568, 105, true);
            WriteLiteral("                            <div class=\"form-group text-danger\">\r\n                                <label>");
            EndContext();
            BeginContext(674, 19, false);
#line 18 "C:\Users\Adimar\source\repos\WebCore\WebCoreSite\Views\Home\Index.cshtml"
                                  Write(Model.MensagensErro);

#line default
#line hidden
            EndContext();
            BeginContext(693, 46, true);
            WriteLiteral("</label>\r\n                            </div>\r\n");
            EndContext();
#line 20 "C:\Users\Adimar\source\repos\WebCore\WebCoreSite\Views\Home\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(770, 58, true);
            WriteLiteral("                            \r\n                            ");
            EndContext();
            BeginContext(829, 76, false);
#line 22 "C:\Users\Adimar\source\repos\WebCore\WebCoreSite\Views\Home\Index.cshtml"
                       Write(await Html.PartialAsync("Partial/_InserirAtualizar", Model.InserirAtualizar));

#line default
#line hidden
            EndContext();
            BeginContext(905, 385, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
            <div class=""card mb-4"">
                <div class=""card-header"">Itens cadastrados:</div>
                <div class=""card-body"">
                    <div class=""sbp-preview"">
                        <div class=""sbp-preview-content"">
                            ");
            EndContext();
            BeginContext(1291, 55, false);
#line 32 "C:\Users\Adimar\source\repos\WebCore\WebCoreSite\Views\Home\Index.cshtml"
                       Write(await Html.PartialAsync("Partial/_Listar", Model.Lista));

#line default
#line hidden
            EndContext();
            BeginContext(1346, 142, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebCoreSite.Models.SPAObjetoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
