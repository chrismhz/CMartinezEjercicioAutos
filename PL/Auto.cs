using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Auto
    {
        public static void GetAllAuto()
        {
            ML.Result result = BL.Auto.GetAllEF();

            if (result.Correct)
            {
                foreach (ML.Auto auto in result.Objects)
                {
                    Console.WriteLine("\nIdAuto: " + auto.IdAuto);
                    Console.WriteLine("Año: " + auto.Año);
                    Console.WriteLine("Kilometraje: " + auto.Kilometraje);
                    Console.WriteLine("Transmision: " + auto.Transmisión);
                    Console.WriteLine("Combustible: " + auto.Combustible);
                    Console.WriteLine("Precio:" + auto.Precio);
                    Console.WriteLine("Marca: " + auto.Marca.Nombre);
                    Console.WriteLine("Modelo: " + auto.Modelo.Nombre);
                    Console.WriteLine("Version: " + auto.Version.Nombre + "\n");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron los registros en la tabla de Autos" + result.ErrorMessage);
            }
        }

        public static void AddEF() 
        { 
            ML.Auto auto = new ML.Auto();

            Console.WriteLine("Ingrese el Año: ");
            auto.Año = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el Color: ");
            auto.Color = Console.ReadLine();

            Console.WriteLine("Ingrese el Kilometraje: ");
            auto.Kilometraje = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el Numero de puertas: ");
            auto.NumeroPuertas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese la transmición: ");
            auto.Transmisión = Console.ReadLine();

            Console.WriteLine("Ingrese el tipo de combustible: ");
            auto.Combustible = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del auto: ");
            string precioInput = Console.ReadLine();
            auto.Precio = decimal.Parse(precioInput);

            Console.WriteLine("Ingrese el IdMarca");
            auto.Marca = new ML.Marca();
            auto.Marca.IdMarca = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el IdModelo");
            auto.Modelo = new ML.Modelo();
            auto.Modelo.IdModelo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el IdVersion");
            auto.Version = new ML.Version();
            auto.Version.IdVersion = Convert.ToInt32(Console.ReadLine());

            ML.Result result = BL.Auto.AddEF(auto);

            if (result.Correct)
            {
                Console.WriteLine("Auto agregado correctamente" + result.Object);
            }
            else
            {
                Console.WriteLine("Error al agregar el auto: " + result.ErrorMessage);
            }
        }
    }
}
