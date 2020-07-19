#pragma checksum "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66b9a5437c8093ecb17fdd1e4fccd3dc1e8a1bd9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Menu__Submenu), @"mvc.1.0.view", @"/Views/Shared/Components/Menu/_Submenu.cshtml")]
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
#line 3 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\_ViewImports.cshtml"
using LojaVirtual.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66b9a5437c8093ecb17fdd1e4fccd3dc1e8a1bd9", @"/Views/Shared/Components/Menu/_Submenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14cc5c6a58e3d403c8bc86e45fe3db3aac6026c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Menu__Submenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
  
    List<Categoria> listaTodasCategorias = (List<Categoria>)ViewData["listaTodasCategorias"];
    Categoria categoriaPai = (Categoria)ViewData["categoriaPai"];
    List<Categoria> listaCategoriaComPaiNivelUm = listaTodasCategorias.Where(x => x.CategoriaPaiId.Equals(categoriaPai.Id)).ToList();

    if (listaCategoriaComPaiNivelUm.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"dropdown-submenu\">\r\n            <a class=\"dropdown-item\" href=\"#\">");
#nullable restore
#line 9 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
                                         Write(categoriaPai.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            <ul class=\"dropdown-menu\">\r\n");
#nullable restore
#line 11 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
                 foreach (Categoria categoriaFilhaNivelUm in listaCategoriaComPaiNivelUm)
                {
                    if (listaTodasCategorias.Where(x => x.CategoriaPaiId.Equals(categoriaFilhaNivelUm.Id)).Count() > 0)
                    {
                        ViewData.Remove("categoriaPai");
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
                   Write(await Html.PartialAsync("~/Views/Shared/Components/Menu/_Submenu.cshtml", new ViewDataDictionary(ViewData) { { "categoriaPai", categoriaFilhaNivelUm } }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
                                                                                                                                                                                  ;
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"dropdown-item\"><a href=\"#\">");
#nullable restore
#line 20 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
                                                         Write(categoriaFilhaNivelUm.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 21 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </li>\r\n");
#nullable restore
#line 25 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"dropdown-item\"><a href=\"#\">");
#nullable restore
#line 28 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
                                         Write(categoriaPai.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 29 "C:\Users\thais\OneDrive\Documents\ASP.NET-CORE-2.2\LojaVirtual\LojaVirtual\Views\Shared\Components\Menu\_Submenu.cshtml"
    }

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
