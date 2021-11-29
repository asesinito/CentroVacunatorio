using CentroDeVacunacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.ConsolaUI
{
    class PersonaIO
    {
        private DireccionIO direccionIO = new DireccionIO();
        private InformacionIO informacionIO = new InformacionIO();
        public Persona IngresarPersona()
        {
            string nombre, apellido, claseDni, nacionalidad;
            int dni;
            DateTime fechaDeNacimiento;      
        
            Console.Clear();
            Console.Write("Ingrese el Nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido");
            apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el Tipo de DNI");
            Console.WriteLine("Libreta Civica, Libreta Verde, Libreta Celeste o DNI Tarjeta.");
            claseDni = Console.ReadLine();
            Console.WriteLine("Ingrese el Numero de DNI");
            dni = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Pais de Origen");
            nacionalidad = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de Nacimiento en el Formato dd/MM/yyyy");
            fechaDeNacimiento = DateTime.Parse(Console.ReadLine());
            Direccion direccion = this.direccionIO.IngresarDireccion();
            Informacion informacion = this.informacionIO.IngresarInformacion();


            return new Persona(nombre, apellido, claseDni, dni, nacionalidad, fechaDeNacimiento, direccion, informacion);
        }

        public void ListarPersonas(List<Persona> personas)
        {
            Console.Clear();
            Console.WriteLine("Personas Registradas");
            
            foreach(Persona persona in personas)
            {
                Console.WriteLine($"{persona.Apellido} - {persona.Nombre} - {persona.ClaseDni} - {persona.Dni} - {persona.FechaDeNacimiento:dd/MM/yy}");
            }
            Console.ReadKey();
        }
    }
}
