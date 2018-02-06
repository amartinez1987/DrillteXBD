using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class PersonasViewModel
    {
        public int? id { get; set; }
        public int? documentoIdentidadId { get; set; }
        public int? municipioId { get; set; }
        public int? grupoSanguineoId { get; set; }
        public int? sexoId { get; set; }
        public int? municipioExpedicionId { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public DateTime? fechaExpedicionCedula { get; set; }
        public int usuarioId { get; set; }
        public int? barrioId { get; set; }
        public decimal? estatura { get; set; }
        public decimal? peso { get; set; }
        public int? estadoCivilId { get; set; }
        public long? telefonoFijo { get; set; }
        public long? telefonoCelular { get; set; }
        public string numeroDocumento { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string direcccion { get; set; }
        public string correo { get; set; }
        
    }
}
