window.addEventListener('load', PedirInfoFiltro(1));
function MostrarDatosAjax(registros) {
    n = TablaListaDispositivos.rows.length;
    for (i = 2; i < n; i++) {
        TablaListaDispositivos.deleteRow(2);
    }
    for (i = 0; i < registros.Lista_Dispositivos.length; i++) {
        row = TablaListaDispositivos.insertRow();
        cell = row.insertCell(0);
        cell.innerHTML = registros.Lista_Dispositivos[i].Serial;
        cell = row.insertCell(1);
        cell.innerHTML = registros.Lista_Dispositivos[i].Ruido;
        cell = row.insertCell(2);
        cell.innerHTML = registros.Lista_Dispositivos[i].FechaHora;
        cell = row.insertCell(3);
        cell.innerHTML = registros.Lista_Dispositivos[i].Ubicacion;
        cell = row.insertCell(4);
        cell.innerHTML = '<a class="btn-secondary btn-sm" href="/Admin/Edit/' + registros.Lista_Dispositivos[i].Id_Dispositivo + '">Editar</a>' + "  " + '<a class="btn-danger btn-sm" href="/Admin/Delete/'+ registros.Lista_Dispositivos[i].Id_Dispositivo +'">Eliminar</a>';

    }
}
function PedirPagMax(pagina) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        InfoFiltro = Input_ID.value + ";" + Input_Dispositivo.value + ";" + Input_Temperatura.value + ";" + Input_FechaHora.value;
        if (xhttp.readyState == 4) {
            if (xhttp.status == 200) {
                PaginaMaxima = xhttp.response;
                B_1.style.display = 'block';
                B_2.style.display = 'block';
                B_3.style.display = 'block';
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
                    if (PaginaMaxima == 1) {
                        B_2.style.display = 'none';
                        B_3.style.display = 'none';
                    }
                    if (PaginaMaxima == 2)
                        B_3.style.display = 'none';
                }
                else if (pagina == PaginaMaxima && PaginaMaxima == 2 ){
                    B_1.style.display = 'none';
                    B_2.innerText = PaginaMaxima - 1;
                    B_3.innerText = PaginaMaxima

                    B_2.onclick = function () { PedirInfoFiltro(PaginaMaxima - 1) }
                    B_3.onclick = function () { PedirInfoFiltro(PaginaMaxima) }

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
    xhttp.open("POST", "/Admin/Pedir_PaginaMax", true);
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
    xhttp.open("POST", "/Admin/PedirInfoFiltro/" + pagina, true);
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