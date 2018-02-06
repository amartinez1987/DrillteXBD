using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class BarriosController
    {

        MoldeEntities entity = new MoldeEntities();

        public MoldeEntities getEntity()
        {
            return entity;
        }
        public List<BarriosViewModel> getListaBarrios( string valorBuscado)
        {
            switch (valorBuscado)
            {
                case "":
                    var l = from barrios in entity.Barrios
                            select new BarriosViewModel { id = barrios.id, municipioId = barrios.municipioId, usuarioId = barrios.usuarioId, nombre = barrios.nombre, codigoDaneDepartamento = barrios.Municipios.Departamentos.codigoDane, codigoDaneMunicipio = barrios.Municipios.codigoDane, nombreDepartamento = barrios.Municipios.Departamentos.nombre, nombreMunicipio = barrios.Municipios.nombre };
                    return l.ToList();
                    
                default:
                    var lb = from barrios in entity.Barrios
                            where (barrios.Municipios.Departamentos.nombre+ " " + barrios.Municipios.nombre).Contains(valorBuscado) || (barrios.Municipios.Departamentos.codigoDane+barrios.Municipios.codigoDane).Contains(valorBuscado) || barrios.nombre.Contains(valorBuscado)
                            select new BarriosViewModel { id = barrios.id, municipioId = barrios.municipioId, usuarioId = barrios.usuarioId, nombre = barrios.nombre, codigoDaneDepartamento = barrios.Municipios.Departamentos.codigoDane, codigoDaneMunicipio = barrios.Municipios.codigoDane, nombreDepartamento = barrios.Municipios.Departamentos.nombre, nombreMunicipio = barrios.Municipios.nombre };
                    return lb.ToList();
                    
            }

        }

        public BarriosViewModel getBarrios(int id)
        {
            var l = from barrios in entity.Barrios
                    where barrios.id == id
                    select new BarriosViewModel { id = barrios.id, municipioId = barrios.municipioId, usuarioId = barrios.usuarioId, nombre = barrios.nombre, codigoDaneDepartamento = barrios.Municipios.Departamentos.codigoDane, codigoDaneMunicipio = barrios.Municipios.codigoDane, nombreDepartamento = barrios.Municipios.Departamentos.nombre, nombreMunicipio = barrios.Municipios.nombre };
            return l.SingleOrDefault();

        }

        public Result guardarBarrios(Barrios registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }


            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("Barrios", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                int barriosId = registro.id;
                Barrios registroEditar = entity.Barrios.Where(x => x.id == barriosId).SingleOrDefault();
                entity.Entry(registroEditar).CurrentValues.SetValues(registro);
                try
                {
                    entity.SaveChanges();
                    return new Result { error = "" };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }
            else
            {
                result = ValidateSession.validarOperacionesForm("Barrios", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                entity.Barrios.Add(registro);
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = registro.id };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }

        }

        private Result validarAtributos(Barrios registro)
        {

            if (registro.municipioId == 0)
            {
                return new Result { error = "Seleccione un municipio.", tipoAlerta = "warning" };
            }

            if (registro.nombre == "")
            {
                return new Result { error = "Digite el nombre del barrio.", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public bool existeRegistro(int barriosId)
        {

            if (entity.Barrios.Where(x => x.id == barriosId).Count() > 0)
                return true;
            return false;

        }
        public Result eliminarBarrios(int barriosId, int usuarioId)
        {

            if (existeRegistro(barriosId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("Barrios", "Eliminar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                Barrios registroEliminar = entity.Barrios.Where(x => x.id == barriosId).SingleOrDefault();
                entity.Barrios.Remove(registroEliminar);
                MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "Barrios", "Eliminado", usuarioId, "AplicacionMolde");
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = barriosId };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }

            }
            return new Result { error = "" };
        }
    }
}
