using CentroDeVacunacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.ConsolaUI
{
    class DireccionIO
    {
        public Direccion IngresarDireccion()
        {
            string ciudad, provincia, codigoPostal, calle, numero;

            Console.Clear();
            Console.WriteLine("Ingrese la Provincia");
            provincia = Console.ReadLine();
            Console.WriteLine("Ingrese la Ciudad");
            ciudad = Console.ReadLine();
            Console.WriteLine("Ingrese la calle");
            calle = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de la calle");
            numero = Console.ReadLine();
            Console.WriteLine("Ingrese el Codigo Postal");
            codigoPostal = Console.ReadLine();

;
            return new Direccion(ciudad, provincia, codigoPostal, calle, numero);
        }
    }
}
