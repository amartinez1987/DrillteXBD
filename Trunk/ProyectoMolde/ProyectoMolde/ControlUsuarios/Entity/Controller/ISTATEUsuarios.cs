using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public interface ISTATEUsuarios
    {

        Result NuevoSinDatosPersona(ref Usuarios registro);

        Result NuevoConDatosPersona(ref Usuarios registro);

        Result Editar(ref Usuarios registro, string tipoModificacionPerfil);

        Result Inactivar(int usuarioId, int usuarioIdApli);

        Result Activar(int usuarioId, int usuarioIdApli);

        Result Activar(ref Usuarios registro);

        Result Inactivar(ref Usuarios registro);

        Result ValidarUsuario(ref Usuarios registro);

        Result RegistrarUsuarioCorreoClave(ref Usuarios registro);

        Result actualizarClave(UsuariosViewModel u, int usuarioId);
    }
}
