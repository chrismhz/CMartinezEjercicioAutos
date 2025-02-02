using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Auto
    {
        
        //Atributos
        public int IdAuto { get; set; } //Propiedades
        public int Año { get; set; }
        public string Color { get; set; }
        public int Kilometraje { get; set; }
        public int NumeroPuertas { get; set; }
        public string Transmisión { get; set; }
        public string Combustible { get; set; }
        public decimal Precio { get; set; }
        public ML.Marca Marca { get; set; }
        public ML.Modelo Modelo { get; set; }
        public ML.Version Version { get; set; }
        public List<Object> Autos { get; set; }
        
    } 
}
