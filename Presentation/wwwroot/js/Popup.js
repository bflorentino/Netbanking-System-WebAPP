const open = document.getElementById("open");
const modalcont = document.getElementById("modal-cont");
const cerrar = document.getElementById("cerrar");
const cerrarRes = document.getElementById("cerrarResponse");
const modalContResponse = document.getElementById("modalResponse")

open.addEventListener("click", () => {
    modalcont.classList.add("show")
})

cerrar.addEventListener("click", () => {
    modalcont.classList.remove("show")
})

cerrarRes.addEventListener("click", () => {
    modalContResponse.classList.remove("show")
})