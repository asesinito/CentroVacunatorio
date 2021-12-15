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
        private VacunacionIO vacunacionIO = new VacunacionIO();

        public Persona IngresarPersona(CentroVacunatorio centroVacunatorio)
        {
            string nombre, apellido, claseDni, nacionalidad;
            int dni;
            DateTime fechaDeNacimiento;      
        
            Console.Clear();
            nombre = IngresarNombre();
            apellido = IngresarApellido();
            Console.WriteLine("Ingrese el Tipo de DNI");
            Console.WriteLine("Libreta Civica, Libreta Verde, Libreta Celeste o DNI Tarjeta.");
            claseDni = Console.ReadLine();
            dni = IngresarDNI();
            Console.WriteLine("Ingrese Pais de Origen");
            nacionalidad = Console.ReadLine();
            fechaDeNacimiento = IngresoFechaNacimiento();
            Direccion direccion = this.direccionIO.IngresarDireccion();
            Informacion informacion = this.informacionIO.IngresarInformacion();
            List<Vacunacion> vacunacionesRegistradas = vacunacionIO.RegistrarVacunacionesHastaParar(centroVacunatorio.Vacunas, centroVacunatorio);

            return new Persona(nombre, apellido, claseDni, dni, nacionalidad, fechaDeNacimiento, direccion, informacion, vacunacionesRegistradas);
        }
        public string IngresarNombre()
        {
            string nombre = "";
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.Write("Ingrese el Nombre: \n");
                    nombre = Console.ReadLine();
                    if(nombre.Length > 0)
                    {
                        nombre.ToUpper();
                        aux = true;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un nombre valido");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar un nombre valido");
                }
            }
            return nombre;
        }
        public string IngresarApellido()
        {
            string Apellido = "";
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.Write("Ingrese el Apellido: \n");
                    Apellido = Console.ReadLine();
                    if (Apellido.Length > 0)
                    {
                        Apellido.ToUpper();
                        aux = true;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un Apellido valido");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar un Apellido valido");
                }
            }
            return Apellido;
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
                    if(newFechaDeNacimiento > fechaDeNacimiento) 
                    { 
                        fechaDeNacimiento = newFechaDeNacimiento;
                        aux = true;
                    }
                    else
                    {
                        Console.WriteLine("La fecha de nacimiento no puede ser posterior a la fecha actual");
                    }
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
                Console.WriteLine($"{persona.Apellido} - {persona.Nombre} - {persona.ClaseDni}: {persona.Dni} - Fecha de Nacimiento {persona.FechaDeNacimiento:dd/MM/yyyy}");
                
                if(persona.Vacunaciones.Count > 0)
                {
                    foreach (Vacunacion vacunacion in persona.Vacunaciones)
                    {
                        Console.WriteLine($"{vacunacion.Vacuna.Nombre} - Dosis -{vacunacion.Dosis} - {vacunacion.FechaYHoraDeVacunacion}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encuentra registro de vacunacion");
                }
                Console.WriteLine("---------------------------------------------------");
            }
            Console.ReadKey();
        }
    }
}
