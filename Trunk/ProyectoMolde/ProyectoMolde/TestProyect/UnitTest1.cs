using ControlUsuarios.Entity.Controller;
using ControlUsuarios.Entity.Model;
using ProyectoMolde.WebMethods;
using System;
using System.Linq;
using Xunit;

namespace TestProyect
{

    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            UsuariosViewModel uv = new UsuariosViewModel()
            {
                barrioId = 3
                ,
                clave = "123"
                ,
                confirmarClave = "123"
                ,
                correo = "ad@hotmail.com"
                ,
                direcccion = ""
                ,
                documentoIdentidadId = 2
                ,
                estado = ""
                ,
                estadoCivilId = 1
                ,
                estatura = 1
                ,
                fechaExpedicionCedula = new DateTime(2007, 09, 16)
                ,
                fechaNacimiento = new DateTime(1987,09,16)
                ,
                grupoSanguineoId = 1
                ,
                id = 0
                ,
                idPersona = 0
                ,
                municipioExpedicionId = 4
                ,
                municipioId = 4
                ,
                nombreUsuario = "a"
                ,
                numeroDocumento = "1142355"
                ,
                peso = 70
                ,
                perfilId = 0
                ,
                primerApellido = "Rosalez de Martinez"
                ,
                primerNombre = "Daniela"
                ,
                segundoApellido = ""
                ,
                segundoNombre = ""
                ,
                sexoId = 1
                ,
                telefonoCelular = 3104012200
                ,
                telefonoFijo = 6666666
                ,
                usuarioId = 1

            };


         Result r=   ProyectoMolde.WebMethods.usuario.nuevo(uv);
        }

        [Fact]
        public void TestMethod2()
        {
            UsuariosViewModel uv = new UsuariosViewModel()
            {
                barrioId = 3
                ,
                clave = "YQBzAGQAZgA="
                ,
                confirmarClave = ""
                ,
                correo = "ad@hotmail.com"
                ,
                direcccion = ""
                ,
                documentoIdentidadId = 2
                ,
                estado = "Activo"
                ,
                estadoCivilId = 1
                ,
                estatura = 1
                ,
                fechaExpedicionCedula = new DateTime(2007, 09, 16)
                ,
                fechaNacimiento = new DateTime(1987, 09, 16)
                ,
                grupoSanguineoId = 1
                ,
                id = 3
                ,
                idPersona = 0
                ,
                municipioExpedicionId = 4
                ,
                municipioId = 4
                ,
                nombreUsuario = "amartinez@coosalud.com"
                ,
                numeroDocumento = "1142355"
                ,
                peso = 70
                ,
                perfilId = 0
                ,
                primerApellido = "Rosalez de Martinez"
                ,
                primerNombre = "Daniela"
                ,
                segundoApellido = ""
                ,
                segundoNombre = ""
                ,
                sexoId = 1
                ,
                telefonoCelular = 3104012200
                ,
                telefonoFijo = 6666666
                ,
                usuarioId = 1

            };


            Result r = ProyectoMolde.WebMethods.usuario.editar(uv,"");
        }


        [Fact]
        public void TestMethod2()
        {
           
        }

    }
}
