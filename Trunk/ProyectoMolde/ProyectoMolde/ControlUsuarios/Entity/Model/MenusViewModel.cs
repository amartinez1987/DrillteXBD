using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class MenusViewModel
    {
        public int id { get; set; }
        public int? aplicacionWebId { get; set; }
        public string nombreAplicacionWeb { get; set; }
        public int usuarioId { get; set; }
        public int indexVisibilidad { get; set; }
        public string nombreMenu { get; set; }
        public string estado { get; set; }
        public string icon { get; set; }
    }
}
