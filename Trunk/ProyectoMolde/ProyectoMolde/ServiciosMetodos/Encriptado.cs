using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMetodos
{
    public class Encriptado
    {
        public Encriptado() 
        {
        
        }
        /// Encripta una cadena
        public static string EncriptarCadena(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}