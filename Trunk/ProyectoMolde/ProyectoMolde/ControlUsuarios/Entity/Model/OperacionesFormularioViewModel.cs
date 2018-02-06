using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class OperacionesFormularioViewModel
    {
        

        public int id { get; set; }
        public int? formularioId { get; set; }
        public string nombreFormulario { get; set; }
        public int? operacionId { get; set; }
        public string nombreOperacion { get; set; }
        public string nombreFormularioOperacion
        {
            get { return string.Format("[{0}] [{1}]", nombreFormulario, nombreOperacion); }
        }
        public int usuarioId { get; set; }
        public string descripcion { get; set; }
    }
}
