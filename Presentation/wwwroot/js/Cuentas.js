
// Agregar dinamicamente un numero de cuenta a un campo de formulario
const insertAccount = (cuenta = "") => {
    document.getElementById("cuentaOrigen").value = cuenta;
}

const insertTarjeta = (tarjeta = "") => document.getElementById("tarjetaDestino").value = tarjeta;

// Peticion Fetch para obtener el balance actual de una cuenta particular de un usuario
const getBalance = (cuenta = "") => {

    fetch(`https://localhost:44322/CuentasClientes/GetCuentaBalance/?cuenta=${cuenta}`)

        .then(function (res) {
            return res.json();
        })

        .then(function (balance) {
            document.getElementById("cuentaOrigen").value = cuenta;
            document.getElementById("balance").value = balance;
        })
}

// Peticion Fetch para obtener el balance de un determinado numero de cuenta
const getBalanceTarjeta = (tarjeta = "") => {
    fetch(`https://localhost:44322/TarjetasClientes/GetTarjetaBalance/?tarjeta=${tarjeta}`)

        .then(function (res) {
            return res.json();
        })

        .then(function (balance) {
            document.getElementById("balanceTarjeta").value = balance;
            document.getElementById("tarjetaDestino").value = tarjeta;
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

// Peticion Fetch para obtener los pagos asociados a una tarjeta en particular
const changeListTarjeta = (tarjeta = "") => {

    fetch(`https://localhost:44322/TarjetasClientes/PagosPorTarjeta/?tarjeta=${tarjeta}`)

        .then((res) => {
            return res.text()
        })

        .then((data) => {
            console.log(data)
            document.getElementById("contPagos").innerHTML = "";
            document.getElementById("contPagos").innerHTML = data;
        })
}
