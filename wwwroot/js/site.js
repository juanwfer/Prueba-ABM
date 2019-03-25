// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var base_url = "https://localhost:44325"

var data = {
    marcas: [],
    newMarca: ''
}

var vm = new Vue({
    el: "#testVue",
    data: data,

    methods: {
        getMarcas: getMarcas,
        deleteMarca: deleteMarca,
        agregarMarca: agregarMarca
    }
})


function getMarcas() {
    $.ajax({
        //pedir galeria de pantallas
        url: base_url + "/Marcas/apiGET",
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

function deleteMarca(id) {
    alert(["Eliminar marca?", "Todos los Modelos, Autos y Ventas asociados a la marca se eliminarán", "Confirmar eliminacion", "Cancelar"])
    $.ajax({
        url: base_url + "/Marcas/apiDELETE/" + id,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function () {
            data.marcas.splice(data.marcas.findIndex((marca) => {
                marca.id == id
            }), 1)
        },
        error: function (er) {
            console.log(er)
        },
        complete: function (marca) {

        }
    })
}

function agregarMarca(nombre) {
    $.ajax({
        url: base_url + "/Marcas/apiCREATE?nombre=" + nombre,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function (marca) {
            data.marcas.push(marca)
        },
        error: function (er) {
            console.log("ERROR", er)
        },
        complete: function (marca) {

        }
    })
}


vm.a == data.a

$(document).ready(getMarcas)