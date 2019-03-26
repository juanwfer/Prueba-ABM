#pragma checksum "C:\Users\juan_\source\repos\Prueba ABM\Prueba ABM\Views\Modelos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1bb4047c2b821406631018a95665cdfa74f45ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Modelos_Index), @"mvc.1.0.view", @"/Views/Modelos/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Modelos/Index.cshtml", typeof(AspNetCore.Views_Modelos_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1bb4047c2b821406631018a95665cdfa74f45ca", @"/Views/Modelos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e48d6b62d05dfba7abbf18fec4a13b9655592784", @"/Views/_ViewImports.cshtml")]
    public class Views_Modelos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("v-for", new global::Microsoft.AspNetCore.Html.HtmlString("marca in marcas"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("v-bind:value", new global::Microsoft.AspNetCore.Html.HtmlString("marca.id"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\juan_\source\repos\Prueba ABM\Prueba ABM\Views\Modelos\Index.cshtml"
  
  ViewData["Title"] = "Modelos";

#line default
#line hidden
            BeginContext(41, 374, true);
            WriteLiteral(@"
<h1>Modelos de autos en el sistema</h1>
<br />
<br />
<div id=""testVue"">
  <table class=""table"">
    <thead>
      <tr>
        <th>ID</th>
        <th>MARCA</th>
        <th>MODELO</th>
        <th>DESCRIPCIÓN</th>
        <th>ACCIÓN</th>
      </tr>
    </thead>
    <tr>
      <td></td>
      <td>
        <select v-model=""newModelo.marca"">
          ");
            EndContext();
            BeginContext(415, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1bb4047c2b821406631018a95665cdfa74f45ca4422", async() => {
                BeginContext(471, 19, true);
                WriteLiteral(" {{ marca.nombre }}");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(499, 968, true);
            WriteLiteral(@"
        </select>
      </td>
      <td><input v-model=""newModelo.nombre"" /></td>
      <td><input v-model=""newModelo.descripcion"" v-on:keyup.enter=""agregarModelo(newModelo)"" /></td>
      <td>
        <button class=""btn btn-primary"" v-on:click=""agregarModelo(newModelo)"">Agregar</button>
        <button class=""btn btn-secondary"" v-on:click=""cancelarNuevo()"">Cancelar</button>
      </td>
    </tr>
    <tbody v-for=""modelo in modelos"">
      <tr>
        <td> {{ modelo.id }}</td>
        <td> {{ modelo.marca }}</td>
        <td> {{ modelo.nombre }}</td>
        <td> {{ modelo.descripcion }}</td>
        <td>
          <button class=""btn btn-outline-secondary"">Editar</button>
          <button class=""btn btn-outline-primary""v-on:click=""getModelo(modelo.id)"">Detalles</button>
          <button class=""btn btn-outline-danger"" v-on:click=""deleteModelo(modelo.id)"">Eliminar</button>
        </td>
      </tr>
    </tbody>
  </table>
</div>");
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
