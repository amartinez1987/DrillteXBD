using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class MunicipiosController
    {
        MoldeEntities entity = new MoldeEntities();


        public MoldeEntities getEntity()
        {
            return entity;
        }

        public List<MunicipiosViewModel> getListaMunicipios(string ValorBuscado)
        {
            switch (ValorBuscado)
            {
                case "":
                    var l = from municipios in entity.Municipios
                            select new MunicipiosViewModel { id = municipios.id, nombre = municipios.nombre, codigoDane = municipios.codigoDane, departamentoId = municipios.departamentoId, usuarioId = municipios.usuarioId,codigoDaneDepartamento=municipios.Departamentos.codigoDane,nombreDepartamento=municipios.Departamentos.nombre};
                    return l.ToList();
                    
                default:
                    var lf = from municipios in entity.Municipios
                             where municipios.nombre.Contains(ValorBuscado)|| municipios.codigoDane.Contains(ValorBuscado)||municipios.Departamentos.codigoDane.Contains(ValorBuscado)||municipios.Departamentos.nombre.Contains(ValorBuscado)
                             select new MunicipiosViewModel { id = municipios.id, nombre = municipios.nombre, codigoDane = municipios.codigoDane, departamentoId = municipios.departamentoId, usuarioId = municipios.usuarioId, codigoDaneDepartamento = municipios.Departamentos.codigoDane, nombreDepartamento = municipios.Departamentos.nombre };
                    return lf.ToList();
                    
            }
        }

   

        public  MunicipiosViewModel getMunicipios(int id)
        {
            
            
                var l = from municipios in entity.Municipios
                        where municipios.id==id
                        select new MunicipiosViewModel { id = municipios.id, departamentoId = municipios.departamentoId, usuarioId = municipios.usuarioId, nombre = municipios.nombre, codigoDane = municipios.codigoDane,codigoDaneDepartamento=municipios.Departamentos.codigoDane,nombreDepartamento=municipios.Departamentos.nombre};
               return l.SingleOrDefault();
            
        }

        public  Result guardarMunicipios(Municipios registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }

            
            
                if (existeRegistro(registro.id))
                {
                    result = ValidateSession.validarOperacionesForm("Municipios", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int municipiosId = registro.id;
                    Municipios registroEditar = entity.Municipios.Where(x => x.id == municipiosId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("Municipios", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    entity.Municipios.Add(registro);
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

        private  Result validarAtributos(Municipios registro)
        {

            if (registro.departamentoId == 0)
            {
                return new Result { error = "Digite el departamento del municipio", tipoAlerta = "warning" };
            }
           
            if (registro.nombre == "")
            {
                return new Result { error = "Digite el nombre", tipoAlerta = "warning" };
            }
            if (registro.codigoDane == "")
            {
                return new Result { error = "Digite el código", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public  bool existeRegistro(int municipiosId)
        {
            
            
                if (entity.Municipios.Where(x => x.id == municipiosId).Count() > 0)
                    return true;
                return false;
            
        }
        public  Result eliminarMunicipios(int municipiosId, int usuarioId)
        {
            
            
                if (existeRegistro(municipiosId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("Municipios", "Eliminar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    Municipios registroEliminar = entity.Municipios.Where(x => x.id == municipiosId).SingleOrDefault();
                    entity.Municipios.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "Municipios", "Eliminado", usuarioId, "AplicacionMolde");
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = municipiosId };
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
