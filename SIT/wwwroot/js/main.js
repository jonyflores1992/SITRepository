
function generateTime() {
    // Capturamos la hora actual mediante la creación de una nueva instancia del objeto Date
    let timeNow = new Date();
    // Queremos que la hora se muestre siempre con 2 dígitos. Para eso, hacemos lo siguiente:
    // Usamos un ternario para saber si el número de digitos es menor que 2
    let hours = timeNow.getHours().toString().length < 2 ? "0" + timeNow.getHours() : timeNow.getHours();
    let minutes = timeNow.getMinutes().toString().length < 2 ? "0" + timeNow.getMinutes() : timeNow.getMinutes();
    //let seconds = timeNow.getSeconds().toString().length < 2 ? "0" + timeNow.getSeconds() : timeNow.getSeconds();

    //  Concatenando variables | Usando ES5
    // let mainTime = hours + ":" + minutes + ":" + seconds;
    //  Concatenando variables | Usando ES6: Template Strings (Template literals)
    //let mainTime = `${hours}:${minutes}:${seconds}`;
    let mainTime = `${hours}:${minutes}`;
    // Escribo la hora en el elemento h1 con id="time"
  // document.getElementById("time").innerHTML = mainTime;
   // document.getElementById("FechaP").innerText = timeNow;

}

setInterval(() => {
    generateTime();
}, 1000);