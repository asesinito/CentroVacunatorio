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
        public Vacunacion RegistrarVacunacion(List<Vacuna> vacunasRegistradas)
        {
            bool deseaVacunar = PreguntarSiDeseaVacunar();
            if (deseaVacunar)
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
                    int dosisAAplicar = RegistroDosis();
                    return new Vacunacion(vacunaRegistrada, dosisAAplicar, DateTime.Now);
                }
            }
            else
            {
                // setear como vacuna defualt que no esta vacunado
                Vacunacion vacunacionPorDefecto = Vacunacion.EstadoDeVacunacionPorDefecto();
                return vacunacionPorDefecto;
            }
        }
        public List<Vacunacion> RegistroDeVacunaciones(List<Vacuna> vacunasRegistradas)
        {
            List<Vacunacion> vacunaciones = new List<Vacunacion>();
            bool aux = false;

            while (!aux)
            {
                try
                {
                    Vacunacion vacunacion = RegistrarVacunacion(vacunasRegistradas);

                    // TODO: FIX THIS
                    if (vacunacion.Vacuna.Nombre == string.Empty)
                    {
                        // La vacuna es por la defualt por ende cancelar el resto de vacunaciones
                        return vacunaciones;
                    }

                    bool noHayRegistroConMismaDosis = !vacunaciones.Any(x => x.Dosis == vacunacion.Dosis);

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
