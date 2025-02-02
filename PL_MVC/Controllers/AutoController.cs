using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        [HttpGet] //Mostrar todos los registros de la tabla Autos
        public ActionResult GetAll()
        {
            ML.Auto auto = new ML.Auto();
            auto.Marca = new ML.Marca();
            auto.Modelo = new ML.Modelo();
            auto.Version = new ML.Version();

            ML.Result result = BL.Auto.GetAllEF();

            if (result.Correct)
            {
                auto.Autos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }
            return View(auto);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Auto auto)
        {
            ML.Result result = BL.Auto.GetAllEF();

            if (result.Correct)
            {
                auto.Autos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }
            return View(auto);
        }

        [HttpGet]//Mostrar el formulario/View
        public ActionResult Form(int? IdAuto)
        {
            ML.Auto auto = new ML.Auto();

            auto.Version = new ML.Version();
            auto.Version.Modelo = new ML.Modelo();
            auto.Version.Modelo.Marca = new ML.Marca();

            ML.Result resultMarca = BL.Marca.GetAllMarca();//Consulta de Marcas

            if (resultMarca.Correct)
            {
                auto.Version.Modelo.Marca.Marcas = resultMarca.Objects.Cast<ML.Marca>().ToList();
            }
            else
            {
                ViewBag.MensajeError = "Error al cargar marcas: " + resultMarca.ErrorMessage;
            }

            return View(auto);
        }

        [HttpPost] //Guarda o Actualiza
        public ActionResult Form(ML.Auto auto)
        {
            ML.Result result = new ML.Result();

            if(auto.IdAuto == 0)
            {
                result = BL.Auto.AddEF(auto); //Agregar

                if (result.Correct)
                {
                    ViewBag.Message = "El registro se ha agregado correctamente";
                }
                else
                {
                    ViewBag.Message = "Hubo un error a la hora de hacer el registro: " + result.ErrorMessage;
                    
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public JsonResult GetModeloGetByIdMarca(int IdMarca)
        {
            ML.Result result = new ML.Result();
            result = BL.Modelo.ModeloGetByIdMarca(IdMarca);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetVersionGetByIdModelo(int IdModelo) 
        {
            ML.Result result = new ML.Result();
            result = BL.Version.VersionGetByIdModelo(IdModelo);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}