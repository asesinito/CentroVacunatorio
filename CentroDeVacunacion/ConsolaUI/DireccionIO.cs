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
        private List<string> provincias = new List<string>
        {
            "Buenos Aires",
            "Capital Federal",
            "Catamarca",
            "Chaco",
            "Chubut",
            "Córdoba",
            "Corrientes",
            "Entre Ríos",
            "Formosa",
            "Jujuy",
            "La Pampa",
            "La Rioja",
            "Mendoza",
            "Misiones",
            "Neuquén",
            "Río Negro",
            "Salta",
            "San Juan",
            "San Luis",
            "Santa Cruz",
            "Santa Fe",
            "Santiago del Estero",
            "Tierra del Fuego",
            "Tucumán",
        };
        public Direccion IngresarDireccion()
        {
            string ciudad, provincia, codigoPostal, calle, numero;

            Console.Clear();
            provincia = MostrarProvincias();
            Console.Clear();
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

        public string MostrarProvincias()
        {
            string provinciaSeleccionada = "";
            bool aux = false;

            while (!aux) 
            {
                try 
                {
                    Console.WriteLine("Seleccione la Provincia de Origen\n");

                    for (int i = 0; i < provincias.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {provincias[i]}");
                    }
                    int indiceSelecionado = int.Parse(Console.ReadLine());
                    provinciaSeleccionada = provincias[indiceSelecionado - 1];
                    aux = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Ha ocurrido un error {ex.Message}");
                }
            }
            return provinciaSeleccionada;
        }
    }
}
