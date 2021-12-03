// Peticion Fetch para obtener los pagos asociados a una tarjeta en particular
const changeListDepositos = (cuenta = "") => {

    fetch(`https://localhost:44322/CuentasClientes/DepositosPorCuenta/?cuenta=${cuenta}`)

        .then((res) => {
            return res.text()
        })

        .then((data) => {
            document.getElementById("depositos").innerHTML = data;
        })
}