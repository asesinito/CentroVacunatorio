using CentroDeVacunacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.ConsolaUI
{
    class VacunasIO
    {
        public Vacuna IngresarVacuna()
        {
            string nombre, pais;

            Console.Clear();
            Console.WriteLine("Ingrese el Nombre de la Vacuna");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Pais de Origen");
            pais = Console.ReadLine();

            return new Vacuna(nombre, pais);
        }

        public void ListarVacunas(List<Vacuna> vacunas)
        {
            Console.Clear();
            Console.WriteLine("Vacunas Registradas");

            foreach(Vacuna vacuna in vacunas)
            {
                Console.WriteLine($"Nombre: {vacuna.Nombre} - Pais de Origen: {vacuna.PaisDeOrigen}");
            }
            Console.ReadKey();
        }
    }
}
