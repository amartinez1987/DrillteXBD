using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class PersonasController
    {
        MoldeEntities entity = new MoldeEntities();

        public MoldeEntities getEntity()
        {
            return entity;
        }
        public List<PersonasViewModel> getListaPersonas()
        {

            var l = from personas in entity.Personas
                    select new PersonasViewModel { fechaNacimiento = personas.fechaNacimiento, fechaExpedicionCedula = personas.fechaExpedicionCedula, id = personas.id, documentoIdentidadId = personas.documentoIdentidadId, municipioId = personas.municipioId, grupoSanguineoId = personas.grupoSanguineoId, sexoId = personas.sexoId, municipioExpedicionId = personas.municipioExpedicionId, usuarioId = personas.usuarioId, barrioId = personas.barrioId, estatura = personas.estatura, peso = personas.peso, estadoCivilId = personas.estadoCivilId, telefonoFijo = personas.telefonoFijo, telefonoCelular = personas.telefonoCelular, numeroDocumento = personas.numeroDocumento, primerNombre = personas.primerNombre, segundoNombre = personas.segundoNombre, primerApellido = personas.primerApellido, segundoApellido = personas.segundoApellido, direcccion = personas.direcccion, correo = personas.correo };
            return l.ToList();

        }

        public  PersonasViewModel getPersonas(int id)
        {
            
                var l = from personas in entity.Personas
                        where personas.id == id
                        select new PersonasViewModel { fechaNacimiento = personas.fechaNacimiento, fechaExpedicionCedula = personas.fechaExpedicionCedula, id = personas.id, documentoIdentidadId = personas.documentoIdentidadId, municipioId = personas.municipioId, grupoSanguineoId = personas.grupoSanguineoId, sexoId = personas.sexoId, municipioExpedicionId = personas.municipioExpedicionId, usuarioId = personas.usuarioId, barrioId = personas.barrioId, estatura = personas.estatura, peso = personas.peso, estadoCivilId = personas.estadoCivilId, telefonoFijo = personas.telefonoFijo, telefonoCelular = personas.telefonoCelular, numeroDocumento = personas.numeroDocumento, primerNombre = personas.primerNombre, segundoNombre = personas.segundoNombre, primerApellido = personas.primerApellido, segundoApellido = personas.segundoApellido, direcccion = personas.direcccion, correo = personas.correo };
                return l.SingleOrDefault();
           
        }

        public Result guardarPersonas(Personas registro, int usuarioAsociado)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }


            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("Personas", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                int personasId = registro.id;
                Personas registroEditar = entity.Personas.Where(x => x.id == personasId).SingleOrDefault();                
                entity.Entry(registroEditar).CurrentValues.SetValues(registro);                
                try
                {
                    entity.SaveChanges();
                    return new Result { error = "", id = registro.id };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = registro.id, tipoAlerta = "warning" };
                }
            }
            else
            {
                result = ValidateSession.validarOperacionesForm("Personas", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                } 
                Usuarios u = entity.Usuarios.Where(x => x.id == usuarioAsociado).SingleOrDefault();
                u.idPersona = registro.id;
                entity.Personas.Add(registro);
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = registro.id };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = registro.id, tipoAlerta = "warning" };
                }
            }

        }

        private Result validarAtributos(Personas registro)
        {
            return new Result() { error = "" };
        }
        public bool existeRegistro(int personasId)
        {
            if (entity.Personas.Where(x => x.id == personasId).Count() > 0)
                return true;
            return false;

        }
        public Result eliminarPersonas(int personasId, int usuarioId)
        {

            if (existeRegistro(personasId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("Personas", "Eliminar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                Personas registroEliminar = entity.Personas.Where(x => x.id == personasId).SingleOrDefault();
                entity.Personas.Remove(registroEliminar);
                MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "Personas", "Eliminado", usuarioId, "AplicacionMolde");
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = personasId };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }

            }
            return new Result { error = "" };
        }

        public Personas getModel(PersonasViewModel persona)
        {
            DateTime f = new DateTime(1800, 01, 01);

            if (persona.fechaExpedicionCedula == null) { persona.fechaExpedicionCedula = f; }
            if (persona.fechaNacimiento == null) { persona.fechaNacimiento = f; }
            if (persona.peso == null) { persona.peso = 0; }
            if (persona.barrioId == null) { persona.barrioId = 0; }
            if (persona.documentoIdentidadId == null) { persona.documentoIdentidadId = 0; }
            if (persona.estadoCivilId == null) { persona.estadoCivilId = 0; }
            if (persona.estatura == null) { persona.estatura = 0; }
            if (persona.grupoSanguineoId == null) { persona.grupoSanguineoId = 0; }
            if (persona.municipioExpedicionId == null) { persona.municipioExpedicionId = 0; }
            if (persona.municipioId == null) { persona.municipioId = 0; }
            if (persona.sexoId == null) { persona.sexoId = 0; }
            if (persona.telefonoCelular == null) { persona.telefonoCelular = 0; }
            if (persona.telefonoFijo == null) { persona.telefonoFijo = 0; }
            if (persona.id == null) { persona.id = 0; }

            Personas p = new Personas()
            {
                barrioId = persona.barrioId.Value,
                correo = persona.correo,
                direcccion = persona.correo,
                documentoIdentidadId = persona.documentoIdentidadId.Value,
                estadoCivilId = persona.estadoCivilId.Value,
                estatura = persona.estatura.Value,
                fechaExpedicionCedula = persona.fechaExpedicionCedula.Value,
                fechaNacimiento = persona.fechaNacimiento.Value,
                grupoSanguineoId = persona.grupoSanguineoId.Value,
                id = persona.id.Value,
                municipioExpedicionId = persona.municipioExpedicionId.Value,
                municipioId = persona.municipioId.Value,
                numeroDocumento = persona.numeroDocumento,
                peso = persona.peso.Value,
                primerApellido = persona.primerApellido.TrimStart(' ').TrimEnd(' '),
                primerNombre = persona.primerNombre.TrimStart(' ').TrimEnd(' '),
                segundoApellido = persona.segundoApellido.TrimStart(' ').TrimEnd(' '),
                segundoNombre = persona.segundoNombre.TrimStart(' ').TrimEnd(' '),
                sexoId = persona.sexoId.Value,
                telefonoCelular = persona.telefonoCelular.Value,
                telefonoFijo = persona.telefonoFijo.Value
                , usuarioId = persona.usuarioId
            };

            return p;
        }
    }
}
