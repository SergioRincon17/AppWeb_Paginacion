using DatosDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Adquirir
    {
        static public List<Dispositivo> AdquirirDispositivosFiltro(int PaginaActual, string id, string nombre, string temp, string fecha)
        {
            var TempList = new List<Dispositivo>();
            using (var db = new DatosDataBase.DataBase_PaginacionEntities())
            {
                TempList = db.Dispositivo.Select(Elementos => new Dispositivo
                {
                    DispositivoID = Elementos.Dispocitivo_ID.ToString(),
                    NombreDispositivo = Elementos.Nombre,
                    TemperaturaDispositivo = Elementos.Temperatura,
                    FechaHoraDispositivo = Elementos.FechaHora.ToString()
                }).ToList();

                if (id != "")
                {
                    TempList = TempList.Where(x => x.DispositivoID.Contains(id)).ToList();
                }
                if (nombre != "")
                {
                    TempList = TempList.Where(x => x.NombreDispositivo.Contains(nombre)).ToList();
                }
                if (temp != "")
                {
                    TempList = TempList.Where(x => x.TemperaturaDispositivo.Contains(temp)).ToList();
                }
                if (fecha != "")
                {
                    TempList = TempList.Where(x => x.FechaHoraDispositivo.Contains(fecha)).ToList();
                }
                if (TempList.Count()/10+1 < PaginaActual)
                    PaginaActual = 1;
                TempList = TempList.Skip((PaginaActual - 1) * 10).Take(10).ToList();

            }
            return TempList;
        }
        static public int Pedir_PaginaMax(string id, string nombre, string temp, string fecha)
        {
            var TempList = new List<Dispositivo>();
            var Pag_Max = 1;
            using (var db = new DatosDataBase.DataBase_PaginacionEntities())
            {
                TempList = db.Dispositivo.Select(Elementos => new Dispositivo
                {
                    DispositivoID = Elementos.Dispocitivo_ID.ToString(),
                    NombreDispositivo = Elementos.Nombre,
                    TemperaturaDispositivo = Elementos.Temperatura,
                    FechaHoraDispositivo = Elementos.FechaHora.ToString()
                }).ToList();

                if (id != "")
                {
                    TempList = TempList.Where(x => x.DispositivoID.Contains(id)).ToList();
                }
                if (nombre != "")
                {
                    TempList = TempList.Where(x => x.NombreDispositivo.Contains(nombre)).ToList();
                }
                if (temp != "")
                {
                    TempList = TempList.Where(x => x.TemperaturaDispositivo.Contains(temp)).ToList();
                }
                if (fecha != "")
                {
                    TempList = TempList.Where(x => x.FechaHoraDispositivo.Contains(fecha)).ToList();
                }
                Pag_Max = TempList.Count();

            }
            if (Pag_Max % 10 == 0)
            {
                return Pag_Max / 10;
            }
            else
            {
                return (Pag_Max / 10) + 1;
            }
        }
        static public bool VerificarUsuario(string correo, string contraseña){
            using(var db=new DatosDataBase.DataBase_PaginacionEntities()){
                var usuario = db.Usuario.Where(x => x.Correo == correo && x.Contraseña == contraseña).FirstOrDefault();
                if (usuario == null) {
                    return false;
                }
                return true;
            }
        }

    }
}
