using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class OpcionesMaestroAnexosViewModel
    {
        public int id { get; set; }
        public int maestroAnexosId { get; set; }
        public string nombreMaestroAnexo { get; set; }
        public int usuarioId { get; set; }
        public string nombreOpcion { get; set; }
    }
}
