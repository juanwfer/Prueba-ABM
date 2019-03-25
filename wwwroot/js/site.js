// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var base_url = "https://localhost:44325"

var data = {
    marcas: [],
    modelos: [],
    autos: [],
    newMarca: '',
    newModelo: {
        nombre: '',
        marca: '',
        descripcion: ''
    },

    newAuto: {
        modelo: '',
        fecha_adquisicion: '',
        precio: ''
    }
}

var vm = new Vue({
    el: "#testVue",
    data: data,

    methods: {
        getMarcas: getMarcas,
        deleteMarca: deleteMarca,
        agregarMarca: agregarMarca,

        getModelos: getModelos,
        deleteModelo: deleteModelo,
        agregarModelo: agregarModelo,

        getAutos: getAutos,
        deleteAutos: deleteAutos,
        agregarAuto: agregarAuto
    }
})

function getModelos() {
    $.ajax({
        //pedir galeria de pantallas
        url: base_url + "/Modelos/apiGET",
        //app_url_pantallas,
        method: 'GET',
        async: true,
        dataType: 'json',
        success: function (modelos) {
            data.modelos = [];
            modelos.forEach((modelo) => {
                data.modelos.push(modelo)
            })
            console.log(modelos);
        },
        error: function (er) {
            console.log("ERROR POR PARTE DE AJAX: ", er);
        },
        complete: function (data) {//console.log("Categorias: LISTO.");
        }
    })
}

function deleteModelo(id) {
    if (confirm("Eliminar modelo?\nTodos los Autos y Ventas asociados a la marca se eliminarán")) {
        $.ajax({
            url: base_url + "/Modelos/apiDELETE/" + id,
            method: 'POST',
            async: true,
            dataType: 'json',
            success: function () {
                data.modelos.splice(data.modelos.findIndex((modelo) => {
                    return modelo.id == id
                }), 1)
            },
            error: function (er) {
                console.log(er)
            },
            complete: function (modelo) {

            }
        })
    }
}

function agregarModelo(newModelo) {
    $.ajax({
        url: base_url + "/Modelos/apiCREATE?nombre=" + newModelo.nombre + "&marca=" + newModelo.marca + "&descripcion=" + newModelo.descripcion,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function (modelo) {
            data.modelos.push(modelo)
            data.newModelo = {
                nombre: '',
                marca: '',
                descripcion: ''
            }
        },
        error: function (er) {
            console.log("ERROR", er)
        },
        complete: function (modelo) {

        }
    })
}

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
    if (confirm("Eliminar marca?\nTodos los Modelos, Autos y Ventas asociados a la marca se eliminarán")) {
        $.ajax({
            url: base_url + "/Marcas/apiDELETE/" + id,
            method: 'POST',
            async: true,
            dataType: 'json',
            success: function () {
                data.marcas.splice(data.marcas.findIndex((marca) => {
                    return marca.id == id
                }), 1)
            },
            error: function (er) {
                console.log(er)
            },
            complete: function (marca) {

            }
        })
    }
}

function agregarMarca(nombre) {
    $.ajax({
        url: base_url + "/Marcas/apiCREATE?nombre=" + nombre,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function (marca) {
            data.marcas.push(marca)
            data.newMarca = ""
        },
        error: function (er) {
            console.log("ERROR", er)
        },
        complete: function (marca) {

        }
    })
}


vm.a == data.a

function comenzar(){
    getMarcas();
    getModelos();
}

$(document).ready(comenzar)