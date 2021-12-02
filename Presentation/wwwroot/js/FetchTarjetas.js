/* Peticion Fetch para obtener el balance disponible de una determinada tarjeta de credito*/
function GetBalanceDisponible(tarjeta = "") {
    alert("Entonces es asi")
    fetch(`https://localhost:44322/TarjetasClientes/GetTarjetaBalanceDisponible/?tarjeta=${tarjeta}`)

        .then(function (res) {
            return res.json();
        })

        .then(function (balance) {
            document.getElementById("balanceTarjeta").value = balance;
            document.getElementById("tarjetaDestino").value = tarjeta;
        })
}