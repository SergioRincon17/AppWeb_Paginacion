function MostrarDatosAjax(registros) {
    n = TablaListaDispositivos.rows.length;
    for (i = 2; i < n; i++) {
        TablaListaDispositivos.deleteRow(2);
    }
    for (i = 0; i < registros.Lista_Dispositivos.length; i++) {
        row = TablaListaDispositivos.insertRow();
        cell = row.insertCell(0);
        cell.innerHTML = registros.Lista_Dispositivos[i].DispositivoID;
        cell = row.insertCell(1);
        cell.innerHTML = registros.Lista_Dispositivos[i].NombreDispositivo;
        cell = row.insertCell(2);
        cell.innerHTML = registros.Lista_Dispositivos[i].TemperaturaDispositivo;
        cell = row.insertCell(3);
        cell.innerHTML = registros.Lista_Dispositivos[i].FechaHoraDispositivo;
    }
}
function PedirPagMax(pagina) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        InfoFiltro = Input_ID.value + ";" + Input_Dispositivo.value + ";" + Input_Temperatura.value + ";" + Input_FechaHora.value;
        if (xhttp.readyState == 4) {
            if (xhttp.status == 200) {
                PaginaMaxima = xhttp.response;
                B_Ultima.onclick = function () { PedirInfoFiltro(PaginaMaxima) }
                if (pagina > 1 && pagina < PaginaMaxima) {
                    B_1.innerText = pagina - 1;
                    B_2.innerText = pagina;
                    B_3.innerText = pagina + 1;

                    B_1.onclick = function () { PedirInfoFiltro(pagina - 1) }
                    B_2.onclick = function () { PedirInfoFiltro(pagina) }
                    B_3.onclick = function () { PedirInfoFiltro(pagina + 1) }
                }
                else if (pagina == 1) {
                    B_1.innerText = 1;
                    B_2.innerText = 2;
                    B_3.innerText = 3;

                    B_1.onclick = function () { PedirInfoFiltro(1) }
                    B_2.onclick = function () { PedirInfoFiltro(2) }
                    B_3.onclick = function () { PedirInfoFiltro(3) }
                }
                else if (pagina == PaginaMaxima) {
                    B_1.innerText = PaginaMaxima - 2;
                    B_2.innerText = PaginaMaxima - 1;
                    B_3.innerText = PaginaMaxima

                    B_1.onclick = function () { PedirInfoFiltro(PaginaMaxima - 2) }
                    B_2.onclick = function () { PedirInfoFiltro(PaginaMaxima - 1) }
                    B_3.onclick = function () { PedirInfoFiltro(PaginaMaxima) }

                }
                else if (pagina > PaginaMaxima) {
                    B_1.innerText = 1;
                    B_2.innerText = 2;
                    B_3.innerText = 3;

                    B_1.onclick = function () { PedirInfoFiltro(1) }
                    B_2.onclick = function () { PedirInfoFiltro(2) }
                    B_3.onclick = function () { PedirInfoFiltro(3) }

                }
                else {
                    console.log("No OK");
                }
            }
        }
    }
    xhttp.open("POST", "/Home/Pedir_PaginaMax", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.responseType = "json";
    xhttp.send("Informacion=" + InfoFiltro);
}
function PedirInfoFiltro(pagina) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        InfoFiltro = Input_ID.value + ";" + Input_Dispositivo.value + ";" + Input_Temperatura.value + ";" + Input_FechaHora.value;
        if (xhttp.readyState == 4) {
            if (xhttp.status == 200) {
                MostrarDatosAjax(xhttp.response);
                PedirPagMax(pagina);
            }
            else {
                console.log("No OK");
            }
        }
    };
    xhttp.open("POST", "/Home/PedirInfoFiltro/" + pagina, true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.responseType = "json";
    xhttp.send("Informacion=" + InfoFiltro);
}
//window.addEventListener('load', PedirDatosdb);
//function PedirDatosdb(pagina) {
//    var xhttp = new XMLHttpRequest();
//    xhttp.open("GET", "/Home/PedirDatosdb_Home/" + pagina, true);
//    xhttp.responseType = "json";
//    xhttp.onreadystatechange = function () {
//        //console.log("ReadyState" + xhttp.readyState);
//        //console.log("Estado" + xhttp.status);
//        if (xhttp.readyState == 4) {
//            if (xhttp.status == 200) {
//                MostrarDatosAjax(xhttp.response);
//                PedirPagMax(pagina);
//            }
//            else {
//                console.log("No OK");
//            }
//        }
//    } 	
//    xhttp.send();
//}