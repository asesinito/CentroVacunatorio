using CentroDeVacunacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.ConsolaUI
{
    class VacunacionIO
    {
        private VacunasIO vacunaIO = new VacunasIO();
        private Vacunacion RegistrarVacunacion(List<Vacuna> vacunasRegistradas, CentroVacunatorio centroVacunatorio)
        {

            // Preguntar si desea usar una vacuna ya registrada o si desea registrar una nueva vacuna
            bool deseaUsarUnaVacunaRegistrada = PreugntarSiDeseaUsarUnaVacunaRegistrada(vacunasRegistradas);
            if (deseaUsarUnaVacunaRegistrada)
            {
                // Check for the vaucunas list
                Console.Clear();
                for (int i = 0; i < vacunasRegistradas.Count; i++)
                {
                    Vacuna vacuna = vacunasRegistradas[i];
                    Console.WriteLine(i + ". " + vacuna.Nombre);
                }
                // Ingresar un indice para registrar una nueva vacuna
                Vacuna vacunaSeleccionada = SeleccionarVacuna(vacunasRegistradas);
                int dosisAAplicar = RegistroDosis();
                return new Vacunacion(vacunaSeleccionada, dosisAAplicar, DateTime.Now);

            }
            else
            {
                Vacuna vacunaRegistrada = vacunaIO.IngresarVacuna();
                centroVacunatorio.RegistrarVacuna(vacunaRegistrada);
                int dosisAAplicar = RegistroDosis();
                return new Vacunacion(vacunaRegistrada, dosisAAplicar, DateTime.Now);
            }
        }

        private Vacunacion RegistroDeVacunaciones(List<Vacuna> vacunasRegistradas, List<Vacunacion> vacunaciones, CentroVacunatorio centroVacunatorio)
        {
            Vacunacion vacunacion = null;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    vacunacion = RegistrarVacunacion(vacunasRegistradas, centroVacunatorio);

                    bool noHayRegistroConMismaDosis = !vacunaciones.Any(x => x.Dosis == vacunacion.Dosis);

                    // TODO: Handlear que el registro sea por orden por ende chequear que en la lista de vacunaciones 
                    // Ya exista la vacunacion con dosis anterior
                    if (noHayRegistroConMismaDosis)
                    {
                        vacunaciones.Add(vacunacion);
                    }
                    else
                    {
                        // Si vacunacion tiene una dosis de vacunaciones registrada, preguntar por cambiar el numero de dosis
                        // O volver a registrarla
                        Console.WriteLine("Ya existe un registro de la dosis que desea aplicar");
                        Console.WriteLine("Vuelva a ingresar los datos");
                        Console.ReadKey();
                    }
                    aux = noHayRegistroConMismaDosis;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ha ocurrido un error {ex.Message}");
                }
            }
            return vacunacion;

        }
        public List<Vacunacion> RegistrarVacunacionesHastaParar(List<Vacuna> vacunasRegistradas, CentroVacunatorio centroVacunatorio)
        {
            List<Vacunacion> vacunaciones = new List<Vacunacion>();
            bool aux = false;

            while (!aux)
            {
                try
                {
                    bool deseaVacunar = PreguntarSiDeseaVacunar();
                    if (deseaVacunar)
                    {
                        bool aux2 = false;
                        while (!aux2)
                        {
                            Vacunacion vacunacion = RegistroDeVacunaciones(vacunasRegistradas, vacunaciones, centroVacunatorio);
                            Console.WriteLine("Desea registrar otra vacunacion [Si/No]");
                            string respuesta = Console.ReadLine();
                            if (respuesta == "No" || respuesta == "no")
                            {
                                aux2 = true;
                                aux = true;
                            }
                            else if (respuesta != "Si" && respuesta != "si")
                            {
                                Console.WriteLine("Debe ingresar Si o No");
                            }
                        }

                    }
                    else
                    {
                        return vacunaciones;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return vacunaciones;
        }

        public int RegistroDosis()
        {
            int dosis = 0;

            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Ingrese a que dosis corresponde. EJ> 1, 2, 3");
                    dosis = int.Parse(Console.ReadLine());
                    aux = dosis > 0;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar un numero");
                }
            }
            return dosis;
        }
        public Vacuna SeleccionarVacuna(List<Vacuna> vacunas)
        {
            Vacuna respuesta = null;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Seleccione una Vacuna de la lista:");
                    int read = int.Parse(Console.ReadLine());
                    if (read >= 0 && read < vacunas.Count)
                    {
                        respuesta = vacunas[read];
                        aux = true;
                    }
                    else
                    {
                        Console.WriteLine("Seleccione un indice valido");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar un numero de la lista");
                }
            }
            return respuesta;
        }
        public bool PreugntarSiDeseaUsarUnaVacunaRegistrada(List<Vacuna> vacunasRegistradas)
        {
            bool respuesta = false;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Utilizar Vacuna ya registrada o Registrar una nueva Vacuna\n");
                    Console.WriteLine("Ingrese [R] para seleccionar una Vacuna Registrada");
                    Console.WriteLine("Ingrese [N] para registrar una nueva Vacuna ");
                    Console.WriteLine("\nLas vacunas ya registradas son:");
                    for (int i = 0; i < vacunasRegistradas.Count; i++)
                    {
                        Vacuna vacuna = vacunasRegistradas[i];
                        Console.WriteLine(i + ". " + vacuna.Nombre);
                    }

                    string read = Console.ReadLine();
                    if (read == "R" || read == "r")
                    {
                        respuesta = true;
                        aux = true;
                    }
                    else if (read == "N" || read == "n")
                    {
                        Console.WriteLine("Por favor ingrese los datos de la vacuna a suministrar");
                        Console.ReadKey();
                        respuesta = false;
                        aux = true;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar Si o No");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar Si o No");
                }
            }
            return respuesta;
        }
        public bool PreguntarSiDeseaVacunar()
        {
            bool respuesta = false;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Desea registrar la pesona como vacunada? [Si/No]");
                    string read = Console.ReadLine();
                    if (read == "Si" || read == "si")
                    {
                        respuesta = true;
                        aux = true;
                    }
                    else if (read == "No" || read == "no")
                    {
                        respuesta = false;
                        aux = true;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar Si o No");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar Si o No");
                }
            }
            return respuesta;
        }

        public void AgregarVacunacionesAPersonasEnRegistro(PersonaIO personaIO, List<Persona> personas, List<Vacuna> vacunasRegistradas, CentroVacunatorio centroVacunatorio)
        {
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el DNI de la persosa a aplicar la dosis");
                    Console.WriteLine("Debe ingresar los numeros sin signos de puntuacion!\n");
                    int dni = int.Parse(Console.ReadLine());
                    Persona persona = personaIO.BuscarPersonaEnRegistro(dni, personas);

                    if(persona != null)
                    {
                        bool aux2 = false;
                        while (!aux2)
                        {
                            Vacunacion vacunacion = RegistroDeVacunaciones(vacunasRegistradas, persona.Vacunaciones, centroVacunatorio);
                            
                            Console.WriteLine("Desea registrar otra vacunacion [Si/No]");
                            string respuesta = Console.ReadLine();
                            if (respuesta == "No" || respuesta == "no")
                            {
                                aux2 = true;
                                aux = true;
                            }
                            else if (respuesta != "Si" && respuesta != "si")
                            {
                                Console.WriteLine("Debe ingresar Si o No");
                            }
                            
                        }
                        centroVacunatorio.EliminarRegistroDePersona(persona);
                        centroVacunatorio.RegistrarPersona(persona);
                    }
                    else
                    {
                        Console.WriteLine("El DNI buscado no se encuentra en la base de datos.");
                        Console.ReadKey();
                        aux = true;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Debe ingresar un numero de documento valido, sin signos de puntuacion. {ex.Message}");
                    Console.ReadKey();
                }
            }
        }
        public void MostrarDosisAplicadasEntreDosFechas(List<Vacunacion> vacunaciones)
        {
            DateTime primeraFecha;
            DateTime segundaFecha;
            int cantidadDeDosisEntreFechas;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Debera ingresar las fechas entre las cuales se realizara la busqueda");
                    Console.WriteLine("Debe ingresar las fechas en el formato dd/MM/yyyy\n");
                    Console.WriteLine("Ingrese la Primera Fecha");
                    primeraFecha = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la Segunda Fecha");
                    segundaFecha = DateTime.Parse(Console.ReadLine());

                    cantidadDeDosisEntreFechas = DosisAplicadasPorFechas(vacunaciones, primeraFecha, segundaFecha);

                    Console.WriteLine($"Entre {primeraFecha:dd/MM/yy} y {segundaFecha:dd/MM/yy} se han aplicado: {cantidadDeDosisEntreFechas} dosis.");
                    Console.ReadKey();
                    aux = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ha ocurrido un error: {ex.Message}");
                    Console.ReadKey();
                }
            }
            
            
        }
        public int DosisAplicadasPorFechas(List<Vacunacion> vacunaciones, DateTime primeraFecha, DateTime segundaFecha)
        {
            int contadorDeDosis = 0;
            DateTime fechaMenor = primeraFecha.Ticks < segundaFecha.Ticks ? primeraFecha : segundaFecha;
            DateTime fechaMayor = primeraFecha.Ticks > segundaFecha.Ticks ? primeraFecha : segundaFecha;
            DateTime diaTerminadoFechaMayor = fechaMayor.AddDays(1);

            foreach(Vacunacion vacunacion in vacunaciones)
            {
                if(vacunacion.FechaYHoraDeVacunacion.Ticks > fechaMenor.Ticks && vacunacion.FechaYHoraDeVacunacion.Ticks < diaTerminadoFechaMayor.Ticks)
                {
                    contadorDeDosis++;
                }
            }
            return contadorDeDosis;
        }

        public Dictionary<Vacuna,int> VacunasPorTipo(List<Vacuna> vacunas, List<Vacunacion> vacunaciones)
        {
            Dictionary<Vacuna, int> diccionarioDeVacunaciones = new Dictionary<Vacuna, int>();

            foreach(Vacuna vacuna in vacunas)
            {
                int contadorDeDosis = 0;

                foreach (Vacunacion vacunacion in vacunaciones)
                {
                    if (vacuna.Nombre == vacunacion.Vacuna.Nombre) 
                    {
                        contadorDeDosis++; 
                    }
                }
                diccionarioDeVacunaciones[vacuna] = contadorDeDosis;
            }

            return diccionarioDeVacunaciones;
        }
    }
}
