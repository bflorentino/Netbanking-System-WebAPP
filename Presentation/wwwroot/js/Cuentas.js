
// Agregar dinamicamente un numero de cuenta a un campo de formulario
const insertAccount = (cuenta = "") => {
    document.getElementById("cuentaOrigen").value = cuenta;
}

// Peticion Fetch para obtener el balance actual de una cuenta particular de un usuario
const getBalance = (cuenta = "") => {

    fetch(`https://localhost:44322/CuentasClientes/GetCuentaBalance/?cuenta=${cuenta}`)

        .then(function (res) {
            return res.json();
        })

        .then(function (mijson) {
            document.getElementById("cuentaOrigen").value = cuenta;
            document.getElementById("balance").value = mijson;
        })
}

// Peticion Fetch para obtener los pagos asociados a un prestamo en particular
const changeList = (prestamo = "") => {

    fetch(`https://localhost:44322/PrestamosClientes/PagosPorPrestamo/?prestamo=${prestamo}`)

        .then((res) => {
            return res.text()
        })

        .then((data) => {
            console.log(data)
            document.getElementById("contPagos").innerHTML = data
        })
}