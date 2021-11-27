
// Peticion Fetch para obtener el balance actual de una cuenta particular de un usuario
const getBalance = (cuenta = "") => {

    fetch(`https://localhost:44322/CuentasClientes/GetCuentaBalance/?cuenta=${cuenta}`)

        .then(function (res) {
            return res.json();
        })

        .then(function (mijson) {
            document.getElementById("balance").value = mijson;
        })
}