using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class BarriosViewModel
    {
        public int id { get; set; }
        public int? municipioId { get; set; }
        public string codigoDaneDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public string codigoDaneMunicipio { get; set; }
        public string nombreMunicipio { get; set; }
        public string nombreDepartamentoMunicipio
        {
            get
            {
                return string.Format("[{0}] [{1}]", nombreDepartamento, nombreMunicipio);
            }
        }
        public string codigoDaneDepartamentoMunicipio
        {
            get
            {
                return string.Format("{0}{1}", codigoDaneDepartamento, codigoDaneMunicipio);

            }
        }
        public int usuarioId { get; set; }
        public string nombre { get; set; }
    }
}
