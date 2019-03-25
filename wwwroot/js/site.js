// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var data = {
    marcas: []
}

var vm = new Vue({
    el: "#testVue",
    data: data,

    methods: {
        getMarcas:getMarcas
    }
})


function getMarcas() {
    $.ajax({
        //pedir galeria de pantallas
        url: "https://localhost:44325/Marcas/API",
        //app_url_pantallas,
        method: 'GET',
        async: true,
        dataType: 'json',
        success: function (marcas) {
            data.marcas = [];
            marcas.forEach((marca) => {
                data.marcas.push(marca)
            })
            console.log(marcas);
        },
        error: function (er) {
            console.log("ERROR POR PARTE DE AJAX: ", er);
        },
        complete: function (data) {//console.log("Categorias: LISTO.");
        }
    })
}

vm.a == data.a

$(document).ready(getMarcas)