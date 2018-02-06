using ControlUsuarios.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUsuarios.Entity.Controller
{
    public class ConsecutivosTemporalesController
    {
        public static string getConsecutivo(int maestroAnexoId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                ConsecutivosTemporales ct = entity.ConsecutivosTemporales.Where(x=>x.maestroAnexoId == maestroAnexoId).FirstOrDefault();
                ct.consecutivo++;
                string consecutivo = ct.MaestroAnexos.tabla + ct.consecutivo.ToString();
                entity.SaveChanges();
                return consecutivo;
            }
        }
    }
}