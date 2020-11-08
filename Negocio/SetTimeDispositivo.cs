using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SetTimeDispositivo
    {
        static public string setTime(int id,string Datos)
        {
            try
            {
                var DatosDispositivo = Datos.Split(new string[] { ";" }, StringSplitOptions.None);
                using (var db = new DatosDataBase.DataBase_PaginacionEntities())
                {
                    db.Dispositivo.Add(new DatosDataBase.Dispositivo
                    {
                        Nombre = DatosDispositivo[0],
                        Temperatura = DatosDispositivo[1],
                        FechaHora = DateTime.Parse(DatosDispositivo[2])
                    });
                    db.SaveChanges();
                }
                return "Hora registrada correctamente";
            }
            catch (Exception) {
                return "Falla";
            }
        }
    }
}
