document.getElementById("myBtn").addEventListener("click", PedirInfoFiltro);
function PedirInfoFiltro() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {

        //Mes
        Fecha_InicialMes = Fecha_Min.value;
        Fecha_InicialMes = Fecha_InicialMes.slice(5, 7);
        Fecha_FinalMes = Fecha_Max.value;
        Fecha_FinalMes = Fecha_FinalMes.slice(5, 7);
        //Dia
        Fecha_InicialDia = Fecha_Min.value;
        Fecha_InicialDia = Fecha_InicialDia.slice(8, 10);
        Fecha_FinalDia = Fecha_Max.value;
        Fecha_FinalDia = Fecha_FinalDia.slice(8, 10);

        InfoFiltro = Fecha_InicialMes + ";" + Fecha_FinalMes + ";" + Fecha_InicialDia + ";" + Fecha_FinalDia + ";" + Ubicacion.value;

        if (xhttp.readyState == 4) {
            if (xhttp.status == 200) {
                $("#myfirstchart").empty();
                var DatosArry = DatosGraf(xhttp.response);

                new Morris.Line({
                    // ID of the element in which to draw the chart.
                    element: 'myfirstchart',
                    // Chart data records -- each entry in this array corresponds to a point on
                    // the chart.
                    data: DatosArry,
                    // The name of the data record attribute that contains x-values.
                    xkey: 'time',
                    // A list of names of data record attributes that contain y-values.
                    ykeys: ['Ruido'],
                    // Labels for the ykeys -- will be displayed when you hover over the
                    // chart.
                    labels: ['Value'],
                    resize: true,
                });
            }
            else {
                console.log("No OK");
            }
        }
    };
    xhttp.open("POST", "/Admin/PedirInfoFiltroGraf", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.responseType = "json";
    xhttp.send("Informacion=" + InfoFiltro);
}

function DatosGraf(response) {
    var arr = [];
    for (var cnt = 0; cnt < response.Lista_Dispositivos.length; cnt++) {
        arr.splice(cnt, 0, { time: '' + response.Lista_Dispositivos[cnt].FechaHora + '', Ruido: response.Lista_Dispositivos[cnt].Ruido });
    }
    return arr;
}





