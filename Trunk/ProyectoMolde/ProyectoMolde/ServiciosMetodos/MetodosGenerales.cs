using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ServiciosMetodos
{
    public class MetodosGenerales
    {
        public static bool validaSoloLetras(string word)
        {
            Regex Val = new Regex("^[A-Z a-z]*$");

            if (Val.IsMatch(word))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static bool validaSoloNumeros(string word)
        {
            Regex Val = new Regex("[^0-9]");

            if (Val.IsMatch(word))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}