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
            DateTime fechaDeVencimiento;

            Console.Clear();
            Console.WriteLine("Ingrese el Nombre de la Vacuna");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Pais de Origen");
            pais = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de Vencimiento en el Formato dd/MM/yyyy");
            fechaDeVencimiento = DateTime.Parse(Console.ReadLine());

            return new Vacuna(nombre, pais, fechaDeVencimiento);
        }

        public void ListarVacunas(List<Vacuna> vacunas)
        {
            Console.Clear();
            Console.WriteLine("Vacunas Registradas");

            foreach(Vacuna vacuna in vacunas)
            {
                Console.WriteLine($"Nombre: {vacuna.Nombre}, Pais de Origen: {vacuna.PaisDeOrigen}, Fecha de Vencimiento: {vacuna.FechaDeVencimiento:dd/MM/yyyy}");
            }
            Console.ReadKey();
        }
    }
}
