#pragma checksum "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Produto\Visualizar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab5ea5ee4e007002683c24ea4445670eb3d419d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto_Visualizar), @"mvc.1.0.view", @"/Views/Produto/Visualizar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab5ea5ee4e007002683c24ea4445670eb3d419d3", @"/Views/Produto/Visualizar.cshtml")]
    public class Views_Produto_Visualizar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LojaVirtual.Models.Produto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h3>Produto -> Visualizar</h3>\r\n:)\r\n\r\n");
#nullable restore
#line 6 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Produto\Visualizar.cshtml"
  
    string nome = "Thaís Tozatto";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>");
#nullable restore
#line 9 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Produto\Visualizar.cshtml"
Write(nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<br/>\r\n<h2>Produto</h2>\r\n\r\n<b>Código: </b> ");
#nullable restore
#line 13 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Produto\Visualizar.cshtml"
           Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br/>\r\n<b>Nome: </b> ");
#nullable restore
#line 14 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Produto\Visualizar.cshtml"
         Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br/>\r\n<b>Descrição: </b> ");
#nullable restore
#line 15 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Produto\Visualizar.cshtml"
              Write(Model.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br/>\r\n<b>Valor: </b> ");
#nullable restore
#line 16 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Produto\Visualizar.cshtml"
          Write(Model.Valor.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";<br/>\r\n\r\n<br />\r\nTodos os direitos reservados &copy; ");
#nullable restore
#line 19 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Produto\Visualizar.cshtml"
                               Write(DateTime.Now.Year);

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LojaVirtual.Models.Produto> Html { get; private set; }
    }
}
#pragma warning restore 1591