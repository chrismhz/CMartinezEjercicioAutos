using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {

                Console.WriteLine("1.- GetAll");
                Console.WriteLine("2.- InsertAutos");
                // -------------------------------------------------------------------
                Console.WriteLine("[3.- Salir]");
                Console.Write("\n\n----- Seleccione el numero de la opcion -----\n");


                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Auto.GetAllAuto();
                            break;
                        case 2:
                            Auto.AddEF();
                            break;
                        case 3:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Vuelva a escriba una opcion ya establecida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error, vuelva a intentarlo");
                }
            }
        }
    }
}
