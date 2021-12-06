
// Peticion Fetch para obtener los pagos asociados a una tarjeta en particular
const  changeListDepositos = (cuenta = "") => {

        fetch(`https://localhost:44322/CuentasClientes/DepositosPorCuenta/?cuenta=${cuenta}`)
        .then((res) => {
            return res.text()
        })
        .then((data) => {
            document.getElementById("acc").value = cuenta;
            document.getElementById("depositos").innerHTML = data
            document.getElementById("valorCuenta").innerHTML = `Cuenta seleccionada: ${cuenta}`
        })
   }

// Peticion Fetch para obtener los pagos asociados a una tarjeta en particular
const changeListRetiros = (cuenta = "") => {
       fetch(`https://localhost:44322/CuentasClientes/RetirosPorCuenta/?cuenta=${cuenta}`)
        .then((res) => {
            return res.text()
        })
        .then((data) => {
            document.getElementById("acc").value = cuenta;
            document.getElementById("depositos").innerHTML = data
            document.getElementById("valorCuenta").innerHTML = `       Cuenta seleccionada: ${cuenta}`
        })
    }

// Peticion Fetch para obtener los pagos asociados a una tarjeta en particular
const GetDepositosPorFecha = () => {

    let fechaIn = document.getElementById("fechaIn").value;
    let fechaFin = document.getElementById("fechaFin").value;
    let cuenta = document.getElementById("acc").value;

        fetch(`https://localhost:44322/CuentasClientes/DepositosEntreFechas/?FechaIn=${fechaIn}&FechaFin=${fechaFin}&cuenta=${cuenta}`)
            .then((res) => {
                return res.text()
            })
            .then((data) => {
                document.getElementById("depositos").innerHTML = data
            })
    }


// Peticion Fetch para obtener los pagos asociados a una tarjeta en particular
const GetRetirosPorFecha = () => {

    let fechaIn = document.getElementById("fechaIn").value;
    let fechaFin = document.getElementById("fechaFin").value;
    let cuenta = document.getElementById("acc").value;

        fetch(`https://localhost:44322/CuentasClientes/RetirosEntreFechas/?FechaIn=${fechaIn}&FechaFin=${fechaFin}&cuenta=${cuenta}`)
        .then((res) => {
        return res.text()
    })
        .then((data) => {
            console.log(data);
        document.getElementById("depositos").innerHTML = data
     })
 }