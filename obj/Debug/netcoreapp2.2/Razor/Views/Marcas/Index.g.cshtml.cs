#pragma checksum "C:\Users\juan_\source\repos\Prueba ABM\Prueba ABM\Views\Marcas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23eadd0d8b31001a0c32d427df7707522216f1e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Marcas_Index), @"mvc.1.0.view", @"/Views/Marcas/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Marcas/Index.cshtml", typeof(AspNetCore.Views_Marcas_Index))]
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
#line 1 "C:\Users\juan_\source\repos\Prueba ABM\Prueba ABM\Views\_ViewImports.cshtml"
using Prueba_ABM;

#line default
#line hidden
#line 2 "C:\Users\juan_\source\repos\Prueba ABM\Prueba ABM\Views\_ViewImports.cshtml"
using Prueba_ABM.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23eadd0d8b31001a0c32d427df7707522216f1e5", @"/Views/Marcas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e48d6b62d05dfba7abbf18fec4a13b9655592784", @"/Views/_ViewImports.cshtml")]
    public class Views_Marcas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\juan_\source\repos\Prueba ABM\Prueba ABM\Views\Marcas\Index.cshtml"
  
  ViewData["Title"] = "Marcas";

#line default
#line hidden
            BeginContext(40, 970, true);
            WriteLiteral(@"
<h1>Marcas de autos en el sistema</h1>
<br />
<br />
<div id=""testVue"">
  <table class=""table"">
    <thead>
      <tr>
        <th>ID</th>
        <th>NOMBRE</th>
        <th>ACCIÓN</th>
      </tr>
    </thead>
    <tr>
      <td></td>
      <td><input v-model=""newMarca"" v-on:keyup.enter=""agregarMarca(newMarca)""/></td>
      <td>
        <button class=""btn btn-primary"" v-on:click=""agregarMarca(newMarca)"">Agregar</button>
        <button class=""btn btn-secondary"">Cancelar</button>
      </td>
    </tr>
    <tbody v-for=""marca in marcas"">
      <tr>
        <td> {{ marca.id }} </td>
        <td> {{ marca.nombre }} </td>
        <td>
          <button class=""btn btn-outline-secondary"">Editar</button>
          <button class=""btn btn-outline-primary"">Detalles</button>
          <button class=""btn btn-outline-danger"" v-on:click=""deleteMarca(marca.id)"">Eliminar</button>
        </td>
      </tr>
    </tbody>
  </table>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
