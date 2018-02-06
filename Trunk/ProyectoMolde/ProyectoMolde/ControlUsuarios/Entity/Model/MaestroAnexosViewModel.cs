using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class MaestroAnexosViewModel
    {
        public int id { get; set; }
        public String tabla { get; set; }
        public int usuarioId { get; set; }
        public int aplicacionId { get; set; }
    }
}
