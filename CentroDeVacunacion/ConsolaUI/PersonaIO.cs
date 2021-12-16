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

        private List<string> clasesDeDNI = new List<string>
        {
            "Libreta Civica",
            "Libreta Verde",
            "Libreta Celeste",
            "DNI Tarjeta"
        };

        public Persona IngresarPersona(CentroVacunatorio centroVacunatorio)
        {
            string nombre, apellido, claseDni, nacionalidad;
            int dni;
            DateTime fechaDeNacimiento;      
        
            Console.Clear();
            nombre = IngresarNombre();
            apellido = IngresarApellido();
            claseDni = MostrarTiposDeDNI();
            dni = IngresarDNI(centroVacunatorio.Personas);
            Console.WriteLine("Ingrese Pais de Origen");
            nacionalidad = Console.ReadLine();
            fechaDeNacimiento = IngresoFechaNacimiento();
            Direccion direccion = direccionIO.IngresarDireccion();
            Informacion informacion = informacionIO.IngresarInformacion();
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
                        Console.WriteLine("No puede ingresar este campo vacio");
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
                        Console.WriteLine("No puede ingresar este campo vacio");
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
                    int compare = DateTime.Compare(newFechaDeNacimiento, fechaDeNacimiento);
                    if(compare < 0) 
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
        public string MostrarTiposDeDNI()
        {
            string tipoDeDniSeleccionado = "";
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Seleccione el Tipo de Documento de Identificacion\n");

                    for (int i = 0; i < clasesDeDNI.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {clasesDeDNI[i]}");
                    }
                    int indiceSelecionado = int.Parse(Console.ReadLine());
                    tipoDeDniSeleccionado = clasesDeDNI[indiceSelecionado - 1];
                    aux = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ha ocurrido un error {ex.Message}");
                }
            }
            return tipoDeDniSeleccionado;
        }

        public int IngresarDNI(List<Persona> personas)
        {
            int dni = 0;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Ingrese el Numero de DNI");
                    dni = int.Parse(Console.ReadLine());
                    if(comprobarSiUnaPersonaYaEstaRegistrda(personas, dni))
                    {
                        aux = true;
                        return dni;
                    }
                    else
                    {
                        Console.WriteLine("Ya hay una persona registrda con ese DNI");
                    }
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Debe ingresar un numero de documento valido");
                }
            }
            return dni;
        }
        public bool comprobarSiUnaPersonaYaEstaRegistrda(List<Persona> personas, int dni)
        {
            foreach(Persona persona in personas)
            {
                if(persona.Dni == dni)
                {
                    return false;
                }
            }
            return true;
        }

        public void BuscarPersonasPorDNI(List<Persona> personas)
        {
            int dni = 0;
            bool aux = false;
            
            try 
            { 
                Console.Clear();
                Console.WriteLine("Ingrese el DNI a buscar");
                Console.WriteLine("Debe ingresar los numeros sin signos de puntuacion!\n");
                dni = int.Parse(Console.ReadLine());

                foreach(Persona persona in personas)
                {
                    if(persona.Dni == dni)
                    {
                        Console.WriteLine($"\nApellido: {persona.Apellido} - Nombre: {persona.Nombre} - Fecha de Nacimiento {persona.FechaDeNacimiento:dd/MM/yyyy}");
                        Console.WriteLine($"Pais de Origen: {persona.Nacionalidad} - Provincia: {persona.Direccion.Provincia} - Ciudad: {persona.Direccion.Ciudad} - Direccion: {persona.Direccion.Calle} {persona.Direccion.Numero}");
                        Console.WriteLine("\nInformacion de contacto");
                        Console.WriteLine($"Telefono: {persona.Informacion.Telefono} - Contacto de Emergencia: {persona.Informacion.TelefonoDeContacto} - Email: {persona.Informacion.Email}");
                        Console.WriteLine("\nRegistro de vacunacion");
                        Console.WriteLine("----------------------------------------------------------");

                        if(persona.Vacunaciones.Count > 0) 
                        { 
                            foreach (Vacunacion vacunacion in persona.Vacunaciones)
                            {
                                Console.WriteLine($"\n{vacunacion.Vacuna.Nombre} - Dosis -{vacunacion.Dosis} - {vacunacion.FechaYHoraDeVacunacion}");
                                Console.WriteLine("----------------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encuentra registro de vacunacion");
                        }
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Debe ingresar un numero de documento valido");
                Console.ReadKey();  
            }
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
