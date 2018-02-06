using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUsuarios.Entity.Model
{
    public class AnexosViewModel
    {
        public int id { get; set; }
        public int opcionMaestroAnexoId { get; set; }
        public string nombreOpcionMaestroAnexo { get; set; }        
        public Nullable<int> registroTablaId { get; set; }
        public int usuarioId { get; set; }
        public byte[] anexo { get; set; }
        public string consecutivosTemporal { get; set; }
        public string nombreAnexo { get; set; }
    }
}