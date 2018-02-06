using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMetodos
{
    public class LogController
    {

        public string guardarLog(string aplicacion, string nombreClase, string funcion, string mensajeError)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Molde\Molde.log", true))
            {
                file.WriteLine("Fecha Hora: " + DateTime.Now + "\tAplicacion: " + aplicacion + "\tClase: " + nombreClase + "\tFuncion: " + funcion + "\t Error: " + mensajeError);
            }

            return "";
        }
    }

}