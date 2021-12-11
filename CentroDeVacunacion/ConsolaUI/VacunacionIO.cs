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
            
                // Preguntar si desea usar una vacuna ya registrada o si desea registrar una nueva vaucna
                bool deseaUsarUnaVacunaRegistrada = PreugntarSiDeseaUsarUnaVacunaRegistrada();
                if (deseaUsarUnaVacunaRegistrada)
                {
                    // Check for the vaucunas list

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
                    // register a new vacuna
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
                    }

                    aux = noHayRegistroConMismaDosis;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar un numero de documento valido");
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
                        // LOOP THIS UNTIL THE USER WANTS TO STOP
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
                        }

                    }
                    else
                    {
                        // setear como vacuna defualt que no esta vacunado
                        // boletear el estado por defecto de la vacuna y chequear por el count de las vacunaicones para etemrinar que no esta vacunado
                        //Vacunacion vacunacionPorDefecto = Vacunacion.EstadoDeVacunacionPorDefecto();
                        //vacunaciones.Add(vacunacionPorDefecto);
                        return vacunaciones;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar un numero de documento valido");
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
                    Console.WriteLine("Debe ingresar un numero");
                }
            }
            return respuesta;
        }
        public bool PreugntarSiDeseaUsarUnaVacunaRegistrada()
        {
            bool respuesta = false;
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Desea usar una vacuna registrada? [Si/No]");
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar Si o No");
                }
            }
            return respuesta;
        }

    }
}
