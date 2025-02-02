using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Marca
    {
        public static ML.Result GetAllMarca()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezEjercicioAutosEntities context = new DL_EF.CMartinezEjercicioAutosEntities())
                {
                    var query = (from marca in context.Marca
                                 select new 
                                 {
                                     marca.IdMarca,
                                     marca.Nombre
                                 }).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Marca marca = new ML.Marca();
                            marca.IdMarca = item.IdMarca;
                            marca.Nombre = item.Nombre;

                            result.Objects.Add(marca);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay estados \n\n";
                    }
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
