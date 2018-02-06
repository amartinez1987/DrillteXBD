using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class GruposSanguineoViewModel
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public string sigla { get; set; }
        public string descripcion { get; set; }
    }
}
