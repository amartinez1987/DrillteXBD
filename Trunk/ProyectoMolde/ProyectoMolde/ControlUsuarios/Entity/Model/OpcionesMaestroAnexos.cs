//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlUsuarios.Entity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OpcionesMaestroAnexos
    {
        public OpcionesMaestroAnexos()
        {
            this.Anexos = new HashSet<Anexos>();
        }
    
        public int id { get; set; }
        public string nombreOpcion { get; set; }
        public int maestroAnexosId { get; set; }
        public int usuarioId { get; set; }
    
        public virtual MaestroAnexos MaestroAnexos { get; set; }
        public virtual ICollection<Anexos> Anexos { get; set; }
    }
}