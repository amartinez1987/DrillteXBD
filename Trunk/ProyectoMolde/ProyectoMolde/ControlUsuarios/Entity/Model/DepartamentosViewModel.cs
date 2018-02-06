using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class DepartamentosViewModel
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public string nombre { get; set; }
        public string codigoDane { get; set; }
    }
}
