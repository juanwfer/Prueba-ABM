// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var base_url = "https://localhost:44325"

var data = {
    marcas: [],
    modelos: [],
    autos: [],

    editMode: false,

    newMarca: '',
    editMarca: {},

    newModelo: {
        nombre: '',
        marca: '',
        descripcion: ''
    },

    editModelo: {
        nombre: '',
        marca: '',
        descripcion: ''
    },

    newAuto: {
        modelo: '',
        marca: '',
        precio: ''
    },

    editAuto: {
        modelo: '',
        marca: '',
        precio: ''
    }
}

var vm = new Vue({
    el: "#testVue",
    data: data,

    methods: {


        toggleEditModelo: toggleEditModelo,

        toggleEditMarca: toggleEditMarca,

        toggleEditAuto: toggleEditAuto,


        getMarcas: getMarcas,
        getMarca: getMarca,
        deleteMarca: deleteMarca,
        agregarMarca: agregarMarca,
        editarMarca: editarMarca,

        getModelos: getModelos,
        getModelo: getModelo,
        deleteModelo: deleteModelo,
        agregarModelo: agregarModelo,
        editarModelo: editarModelo,

        getAutos: getAutos,
        getAuto: getAuto,
        deleteAuto: deleteAuto,
        agregarAuto: agregarAuto,
        editarAuto: editarAuto,

        cancelarNuevo: cancelarNuevo,

        modelosFiltrados: function () {
            return data.modelos.filter(mod => mod.marca == data.newAuto.marca)
        },

        modelosFiltradosEdit: function () {
            return data.modelos.filter(mod => mod.marca == data.editAuto.marca)
        }
    }
})

function toggleEditModelo(modelo) {
    data.editMode = !data.editMode
    if (data.editMode) {
        Object.assign(data.editModelo, modelo)
    }
}

function toggleEditMarca(marca) {
    data.editMode = !data.editMode
    if (data.editMode) {
        Object.assign(data.editMarca, marca)
    }
}

function toggleEditAuto(auto) {
    data.editMode = !data.editMode
    if (data.editMode) {
        Object.assign(data.editAuto, auto)
        data.editAuto.fecha = new Date(data.editAuto.fecha).toISOString().split('T')[0]
        console.log(data.editAuto.fecha)
    }
}

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
                auto.fecha = new Date(auto.fecha).toDateString()
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
    if (confirm("Eliminar auto?")) {
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
        url: base_url + "/Autos/apiCREATE?precio=" + newAuto.precio + "&modelo=" + newAuto.modeloId + "&fecha=" + newAuto.fecha,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function (auto) {
            auto[0].fecha = new Date(auto[0].fecha).toDateString()
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

function editarAuto(auto) {
    $.ajax({
        url: base_url + "/Autos/apiEDIT?identificador=" + auto.id + "&precio=" + auto.precio + "&modelo=" + auto.modeloId + "&fecha=" + auto.fecha,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function (auto) {
            data.editMode = false;
            getAutos()
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
    if (confirm("Eliminar modelo?\nTodos los Autos asociados al modelo se eliminarán")) {
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
                descripcion: '',
                editando: false
            }
        },
        error: function (er) {
            console.log("ERROR", er)
        },
        complete: function (modelo) {

        }
    })
}

function editarModelo(modelo) {
    $.ajax({
        url: base_url + "/Modelos/apiEDIT?identificador=" + modelo.id + "&nombre=" + modelo.nombre + "&marca=" + modelo.marcaId + "&descripcion=" + modelo.descripcion,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function (modelo) {
            data.editMode = false;
            getModelos()
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
    if (confirm("Eliminar marca?\nTodos los Modelos y Autos asociados a la marca se eliminarán")) {
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

function editarMarca(marca) {
    $.ajax({
        url: base_url + "/Marcas/apiEDIT?identificador=" + marca.id + "&nombre=" + marca.nombre,
        method: 'POST',
        async: true,
        dataType: 'json',
        success: function (marca) {
            data.editMode = false;
            getMarcas()
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