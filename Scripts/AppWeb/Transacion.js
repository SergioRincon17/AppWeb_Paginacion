//window.addEventListener('load', PedirDatosdb);
function PedirDatosdb(pagina) {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "/Home/PedirDatosdb_Home/" + pagina, true);
    xhttp.responseType = "json";
    xhttp.onreadystatechange = function () {
        //console.log("ReadyState" + xhttp.readyState);
        //console.log("Estado" + xhttp.status);
        if (xhttp.readyState == 4) {
            if (xhttp.status == 200) {
                console.log("OK");
                console.log(xhttp.response);
                MostrarDatosAjax(xhttp.response);
                console.log("ssssssssssssssssssssssssssssss")
                if (pagina > 1 && pagina<10 ) {
                    B_1.innerText = pagina - 1;
                    B_2.innerText = pagina;
                    B_3.innerText = pagina + 1;

                    B_1.onclick = function () {
                        PedirDatosdb(pagina - 1)
                    }
                    B_2.onclick = function () {
                        PedirDatosdb(pagina)
                    }
                    B_3.onclick = function () {
                        PedirDatosdb(pagina + 1)
                    }
                }

            }
            else {
                console.log("No OK");
            }
        }
    } 	
    console.log("Listo para consultar");
    xhttp.send();
    console.log("Consultado");
}
function MostrarDatosAjax(registros) {
    n = TablaListaDispositivos.rows.length;
    for (i = 1; i < n; i++) {
        TablaListaDispositivos.deleteRow(1);
    }
    console.log("Tamaño :" + registros.Lista_Dispositivos.length);
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
