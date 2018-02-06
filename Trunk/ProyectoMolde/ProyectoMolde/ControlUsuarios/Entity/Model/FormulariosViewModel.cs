using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class FormulariosViewModel
    {
        public int id { get; set; }
        public int menuId { get; set; }
        public string nombreMenu { get; set; }
        public int usuarioId { get; set; }
        public int indexVisibilidad { get; set; }
        public bool esVisible { get; set; }
        public string nombreFormulario { get; set; }
        public string urlFormulario { get; set; }
        public string nombreMostrar { get; set; }
        public string estados { get; set; }
        public string iconOpcion { get; set; }
    }
}
