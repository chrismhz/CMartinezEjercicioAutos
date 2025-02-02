using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Version
    {
        public static ML.Result VersionGetByIdModelo(int IdModelo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezEjercicioAutosEntities context = new DL_EF.CMartinezEjercicioAutosEntities())
                {
                    var query = (from version in context.Version
                                 where version.IdModelo == IdModelo
                                 select new
                                 {
                                     version.IdVersion,
                                     version.Nombre,
                                     version.IdModelo
                                 }).ToList();

                    if (query != null && query.Count >0)
                    {
                        result.Objects = new List<object>();

                        foreach (var version in query)
                        {
                            ML.Version versionitem = new ML.Version();
                            versionitem.IdVersion = version.IdVersion;
                            versionitem.Nombre = version.Nombre;
                            versionitem.Modelo = new ML.Modelo();

                            result.Objects.Add(versionitem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron versiones para el modelo seleccionado.";
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
