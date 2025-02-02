using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Modelo
    {
        public static ML.Result ModeloGetByIdMarca(int IdMarca)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezEjercicioAutosEntities context = new DL_EF.CMartinezEjercicioAutosEntities())
                {
                    var query = (from modelo in context.Modelo
                                 where modelo.IdMarca == IdMarca
                                 select new
                                 {
                                     modelo.IdModelo,
                                     modelo.Nombre
                                 }).ToList();

                    result.Objects = query.Select(modelo => new ML.Modelo
                    {
                        IdModelo = modelo.IdModelo,
                        Nombre = modelo.Nombre
                    }).Cast<object>().ToList();

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
