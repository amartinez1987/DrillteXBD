using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUsuarios.Entity.Model
{
    public class Result
    {
        public int id { set; get; }
        public string error { set; get; }
        public string tipoAlerta { set; get; }
        public string getCadena { set; get; }
        public int totalRegistros { set; get; }
    }
}