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
        marca: '',
        precio: ''
    }
}

var vm = new Vue({
    el: "#testVue",
    data: data,

    methods: {
        getMarcas: getMarcas,
        getMarca: getMarca,
        deleteMarca: deleteMarca,
        agregarMarca: agregarMarca,

        getModelos: getModelos,
        getModelo: getModelo,
        deleteModelo: deleteModelo,
        agregarModelo: agregarModelo,

        getAutos: getAutos,
        getAuto: getAuto,
        deleteAuto: deleteAuto,
        agregarAuto: agregarAuto,

        cancelarNuevo: cancelarNuevo,

        modelosFiltrados: function () {
            return data.modelos.filter(mod => mod.marca == data.newAuto.marca)
        }
    }
})

function cancelarNuevo() {
    data.newMarca = ''

    data.newModelo = {
        nombre: '',
        marca: '',
        descripcion: ''
    }

    data.newAuto = {
        modelo: '',
        marca: '',
        precio: ''
    }
}

function getAutos() {
    $.ajax({
        //pedir galeria de pantallas
        url: base_url + "/Autos/apiGET",
        //app_url_pantallas,
        method: 'GET',
        async: true,
        dataType: 'json',
        success: function (autos) {
            data.autos = [];
            autos.forEach((auto) => {
                data.autos.push(auto)
            })
            console.log(autos);
        },
        error: function (er) {
            console.log("AUTOS: ERROR POR PARTE DE AJAX: ", er);
        },
        complete: function (data) {//console.log("Categorias: LISTO.");
        }
    })
}

function getAuto(id) {
    $.ajax({
        //pedir galeria de pantallas
        url: base_url + "/Autos/apiGETUNIQUE/" + id,
        //app_url_pantallas,
        method: 'GET',
        async: true,
        dataType: 'json',
        success: function (auto) {
            data.autos.push(auto[0])
            console.log(auto[0]);
        },
        error: function (er) {
            console.log("ERROR POR PARTE DE AJAX: ", er);
        },
        complete: function (auto) {//console.log("Categorias: LISTO.");
        }
    })
}

function deleteAuto(id) {
    if (confirm("Eliminar auto?\nTodas las Ventas asociados al auto se eliminarán")) {
        $.ajax({
            url: base_url + "/Autos/apiDELETE/" + id,
            method: 'POST',
            async: true,
            dataType: 'json',
            success: function () {
                data.autos.splice(data.autos.findIndex((auto) => {
                    return auto.id == id
                }), 1)
            },
            error: function (er) {
                console.log(er)
            },
            complete: function (auto) {

            }
        })
    }
}

function agregarAuto(newAuto) {
    $.ajax({
        url: base_url + "/Autos/apiCREATE?precio=" + newAuto.precio + "&modelo=" + newAuto.modelo,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function (auto) {
            data.autos.push(auto[0])
            data.newAuto = {
                precio: '',
                modelo: '',
                marca: ''
            }
        },
        error: function (er) {
            console.log("ERROR", er)
        },
        complete: function (auto) {

        }
    })
}

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

function getModelo(id) {
    $.ajax({
        //pedir galeria de pantallas
        url: base_url + "/Modelos/apiGETUNIQUE/" + id,
        //app_url_pantallas,
        method: 'GET',
        async: true,
        dataType: 'json',
        success: function (modelo) {
            data.modelos.push(modelo[0])
            console.log(modelo[0]);
        },
        error: function (er) {
            console.log("ERROR POR PARTE DE AJAX: ", er);
        },
        complete: function (data) {//console.log("Categorias: LISTO.");
        }
    })
}

function deleteModelo(id) {
    if (confirm("Eliminar modelo?\nTodos los Autos y Ventas asociados al modelo se eliminarán")) {
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
            data.modelos.push(modelo[0])
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
        complete: function (marca) {//console.log("Categorias: LISTO.");
        }
    })
}

function getMarca(id) {
    $.ajax({
        //pedir galeria de pantallas
        url: base_url + "/Marcas/apiGETUNIQUE/" + id,
        //app_url_pantallas,
        method: 'GET',
        async: true,
        dataType: 'json',
        success: function (marca) {
            data.marcas.push(marca)
            console.log(marca)
        },
        error: function (er) {
            console.log("ERROR POR PARTE DE AJAX: ", er);
        },
        complete: function (marca) {//console.log("Categorias: LISTO.");
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

function comenzar() {
    getMarcas();
    getModelos();
    getAutos();
}

$(document).ready(comenzar)