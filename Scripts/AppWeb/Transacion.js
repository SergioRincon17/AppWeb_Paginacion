function PedirDatosdb (){
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "PedirDatosdb", true);
    xhttp.onreadystatechange = function () {
        var Estado = xhttp.status;
        console.log("ReadyState" + xhttp.readyState);
        Console.log("Estado" + Estado)
    } 	
    xhttp.send();
}