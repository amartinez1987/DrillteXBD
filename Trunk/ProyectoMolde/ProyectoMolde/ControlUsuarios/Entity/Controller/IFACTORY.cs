namespace ControlUsuarios.Entity.Controller
{
    public class IFACTORY
    {
        public static ISTATEUsuarios createUsuarios(string state)
        {
            switch (state)
            {
                case "Nuevo":
                    return new ISTATEUsuarios_Nuevo();
                case "Activo":
                    return new ISTATEUsuarios_Activo();
                case "Inactivo":
                    return new ISTATEUsuarios_Inactivo();
                case "Bloqueado":
                    return new ISTATEUsuarios_Bloqueado();
                default:
                    return null;
            }
        }
    }
}
