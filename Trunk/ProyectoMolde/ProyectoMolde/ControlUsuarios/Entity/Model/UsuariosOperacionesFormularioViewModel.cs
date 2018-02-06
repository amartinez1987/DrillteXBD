using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class UsuariosOperacionesFormularioViewModel
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public string nombreUsuario { get; set; }        
        public int operacionFormularioId { get; set; }
        public string nombreFormulario { get; set; }
        public string nombreOperacion { get; set; }
        public string nombreOperacionFormulario
        {
            get
            {
                return string.Format("[{0}] [{1}]", nombreFormulario, nombreOperacion);
            }
        }
        public int usuarioIdApl { get; set; }
    }
}
