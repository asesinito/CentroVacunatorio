using CentroDeVacunacion.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Console.Write("Ingrese el Nombre: \n");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido");
            apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el Tipo de DNI");
            Console.WriteLine("Libreta Civica, Libreta Verde, Libreta Celeste o DNI Tarjeta.");
            claseDni = Console.ReadLine();
            dni = IngresarDNI();
            Console.WriteLine("Ingrese Pais de Origen");
            nacionalidad = Console.ReadLine();
            fechaDeNacimiento = IngresoFechaNacimiento();
            Direccion direccion = this.direccionIO.IngresarDireccion();
            Informacion informacion = this.informacionIO.IngresarInformacion();


            return new Persona(nombre, apellido, claseDni, dni, nacionalidad, fechaDeNacimiento, direccion, informacion);
        }

        public DateTime IngresoFechaNacimiento()
        {
            CultureInfo cultura = CultureInfo.CreateSpecificCulture("es-AR");
            DateTime fechaDeNacimiento = DateTime.Now;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Ingrese la fecha de Nacimiento en el Formato dd/MM/yyyy");
                    DateTime newFechaDeNacimiento = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", cultura);
                    fechaDeNacimiento = newFechaDeNacimiento;
                    aux = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Debe ingresar la Fecha de Nacimiento en el formato dd/MM/yyyy");
                }
            }
            return fechaDeNacimiento;
        }

        public int IngresarDNI()
        {
            int dni = 0;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Ingrese el Numero de DNI");
                    dni = int.Parse(Console.ReadLine());
                    aux = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Debe ingresar un numero de documento valido");
                }
            }
            return dni;
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
