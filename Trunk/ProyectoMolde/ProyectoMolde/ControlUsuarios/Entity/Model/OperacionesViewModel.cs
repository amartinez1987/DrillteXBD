using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class OperacionesViewModel
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public string nombreOperacion { get; set; }
        public bool visualizaFormularioMenu { get; set; }

    }
}
