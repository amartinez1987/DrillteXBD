using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class MunicipiosViewModel
    {
        public int id { get; set; }
        public int departamentoId { get; set; }
        public string nombreDepartamento { get; set; }
        public string codigoDaneDepartamento { get; set; }
        public int usuarioId { get; set; }
        public string nombre { get; set; }
        public string codigoDane { get; set; }
        public string nombreDepartamentoMunicipio
        {
            get
            {
                return string.Format("[{0}] [{1}]", nombreDepartamento, nombre);
            }
        }
        public string codigoDaneDepartamentoMunicipio
        {
            get
            {
                return string.Format("{0}{1}", codigoDaneDepartamento, codigoDane);

            }
        }


    }
}
