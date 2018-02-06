using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Model
{
    public class UsuariosViewModel
    {
        public int id { get; set; }
        public int? idPersona { get; set; }
        public int? usuarioId { get; set; }
        public int perfilId { get; set; }
        public string nombrePerfil { get; set; }
        public string nombreUsuario { get; set; }
        public string clave { get; set; }
        public string confirmarClave { get; set; }
        public string estado { get; set; }
        //Datos Persona
        public int? documentoIdentidadId { get; set; }
        public string siglaDocumentoIdentidad { get; set; }
        public string descripcionDocumentoIdentidad { get; set; }
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
        public int? grupoSanguineoId { get; set; }
        public string siglaGrupoSanguineo { get; set; }
        public string descripcionGrupoSanguineo { get; set; }
        public int? sexoId { get; set; }
        public string siglaSexo { get; set; }
        public string descripcionSexo { get; set; }
        public int? municipioExpedicionId { get; set; }
        public string codigoDaneDepartamentoExpedicion { get; set; }
        public string nombreDepartamentoExpedicion { get; set; }
        public string codigoDaneMunicipioExpedicion { get; set; }
        public string nombreMunicipioExpedicion { get; set; }
        public string nombreDepartamentoMunicipioExpedicion
        {
            get
            {
                return string.Format("[{0}] [{1}]", nombreDepartamentoExpedicion, nombreMunicipioExpedicion);
            }
        }
        public string codigoDaneDepartamentoMunicipioExpedicion
        {
            get
            {
                return string.Format("{0}{1}", codigoDaneDepartamentoExpedicion, codigoDaneMunicipioExpedicion);

            }
        }
        public int? barrioId { get; set; }
        public string nombreDepartamentoBarrio { get; set; }
        public string nombreMunicipioBarrio { get; set; }
        public string nombreoBarrio { get; set; }
        public string nombreBarrioDepartamentoMunicipio 
        {
            get
            {
                return string.Format("[{0}] [{1}] [{2}]", nombreDepartamentoBarrio, nombreMunicipioBarrio, nombreoBarrio);
            }
        }
        public decimal? estatura { get; set; }
        public decimal? peso { get; set; }
        public int? estadoCivilId { get; set; }
        public string nombreEstadoCivil { get; set; }
        public long? telefonoFijo { get; set; }
        public long? telefonoCelular { get; set; }
        public string numeroDocumento { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string nombreCompletoPersona 
        { 
            get 
            {
                return string.Format("{0} {1} {2} {3} ", primerNombre, segundoNombre, primerApellido, segundoApellido);
            }
        }
        public string direcccion { get; set; }
        public string correo { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public DateTime? fechaExpedicionCedula { get; set; }
        
    }
}
