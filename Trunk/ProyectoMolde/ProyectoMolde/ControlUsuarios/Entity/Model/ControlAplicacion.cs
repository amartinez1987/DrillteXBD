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
    
    public partial class ControlAplicacion
    {
        public int id { get; set; }
        public string version { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string estado { get; set; }
        public int usuarioId { get; set; }
    }
}
