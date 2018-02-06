using ServiciosMetodos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ControlUsuarios.Entity.Controller
{
    public class MoldeTrasabilidad
    {
        public static void trasabilidadObject(object obj, string tablaTrasabildiad, string operacion, int usuarioId, string userNameBd)
        {
            string parametros = "";
            string valores = "";

            System.Type type = obj.GetType();
            foreach (PropertyInfo item in type.BaseType.GetProperties())
            {
                switch (item.PropertyType.Name.ToLower())
                {
                    case "int32":
                        parametros += item.Name + ",";
                        valores +=( item.Name == "usuarioId" ? usuarioId.ToString() : item.GetValue(obj, null)) + ",";
                        break;
                    case "string":
                        parametros += item.Name + ",";
                        valores += "'" + item.GetValue(obj, null) + "',";
                        break;
                }
            }

            parametros += "userNameBd"+",Operacion";
            valores += "'"+userNameBd+"'"+",'"+operacion+"'";
            string insertQuery = string.Format("insert into {0} ({1}) values ({2})", tablaTrasabildiad, parametros, valores);
            
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["MoldeTrasabilidad"].ConnectionString;
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand comand = new SqlCommand(insertQuery, con);
                comand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                new Mail().EnviarEmail("AnibalMartinez87@hotmail.com", "Error al realizar Trazabilidad", ex.Message);
            }
        }

    }
}