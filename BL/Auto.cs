using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Auto
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezEjercicioAutosEntities context = new DL_EF.CMartinezEjercicioAutosEntities())
                {
                    var listaAutos = context.GetAllAutos().ToList();

                    if (listaAutos.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var auto in listaAutos)
                        {
                            ML.Auto autoitem = new ML.Auto();
                            autoitem.IdAuto = auto.IdAuto;
                            autoitem.Año = auto.Año;
                            autoitem.Color = auto.Color;
                            autoitem.Kilometraje = (int)auto.Kilometraje;
                            autoitem.NumeroPuertas = (int)auto.NumeroPuertas;
                            autoitem.Transmisión = auto.Transmisión;
                            autoitem.Combustible = auto.Combustible;
                            autoitem.Precio = (decimal)auto.Precio;
                            autoitem.Marca = new ML.Marca();
                            autoitem.Marca.Nombre = auto.MarcaNombre;
                            autoitem.Modelo = new ML.Modelo();
                            autoitem.Modelo.Nombre = auto.ModeloNombre;
                            autoitem.Version = new ML.Version();
                            autoitem.Version.Nombre = auto.VersionNombre;
                            result.Objects.Add(autoitem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Materia \n\n";
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

        public static ML.Result AddEF(ML.Auto auto)
        {
            ML.Result result = new ML.Result();

            try
            {
                // Inicializar las propiedades si son null
                if (auto.Marca == null)
                {
                    auto.Marca = new ML.Marca();
                }
                if (auto.Modelo == null)
                {
                    auto.Modelo = new ML.Modelo();
                }
                if (auto.Version == null)
                {
                    auto.Version = new ML.Version();
                }
                // Se validan si los Ids son correctos (que no sean 0 o valores no válidos)
                if (auto.Marca.IdMarca == 0)
                {
                    // Se asignan si un IdMarca/IdModelo/IdVersion es válido o no
                    auto.Marca.IdMarca = 1; // Permite tener un valor a uno válido existente en la tabla Marca
                }

                if (auto.Modelo.IdModelo == 0)
                {
                    
                    auto.Modelo.IdModelo = 1; 
                }

                if (auto.Version.IdVersion == 0)
                {
                    
                    auto.Version.IdVersion = 1; 
                }

                using (DL_EF.CMartinezEjercicioAutosEntities context = new DL_EF.CMartinezEjercicioAutosEntities())
                {
                    context.AutoInsert(auto.Año,
                                       auto.Color,
                                       auto.Kilometraje,
                                       auto.NumeroPuertas,
                                       auto.Transmisión,
                                       auto.Combustible,
                                       auto.Precio,
                                       auto.Marca.IdMarca,
                                       auto.Modelo.IdModelo,
                                       auto.Version.IdVersion);
                    context.SaveChanges();

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
