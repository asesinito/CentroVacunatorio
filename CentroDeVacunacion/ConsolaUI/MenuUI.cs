using CentroDeVacunacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.ConsolaUI
{
    class MenuUI
    {
        private CentroVacunatorio centroVacunatorio = new CentroVacunatorio();
        private PersonaIO personaIO = new PersonaIO();
        private VacunasIO vacunaIO = new VacunasIO();
        private VacunacionIO vacunacionIO = new VacunacionIO();

        public void MenuPrincipal()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();

                Console.WriteLine("Bienvenido al Centro de Vacunacion COIVD-19\n");
                Console.WriteLine("1. Registrar Persona");
                Console.WriteLine("2. Registrar Aplicacion de Dosis");
                Console.WriteLine("3. Ver registro de Personas");
                Console.WriteLine("4. Ingresar nueva vacuna al registro");
                Console.WriteLine("5. Ver vacunas registradas");
                Console.WriteLine("6. Ver dosis aplicadas");
                Console.WriteLine("7. Buscar persona por DNI\n");
                Console.WriteLine("0. Salir");

                int opcion = this.LeerOpcionValida(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 0 });

                switch (opcion)
                {
                    case 1:
                        {
                            this.IngresarPersona(centroVacunatorio.Vacunas);
                            break;
                        }
                    case 2:
                        {
                            this.IngresarPersona(centroVacunatorio.Vacunas);
                            break;
                        }
                    case 3:
                        {
                            this.ListarPersonas();
                            break;
                        }
                    case 4:
                        {
                            this.IngresarVacuna();
                            break;
                        }
                    case 5:
                        {
                            this.ListarVacuna();
                            break;
                        }
                    case 6:
                        {
                            this.DosisSegunTipoDeVacuna();
                            break;
                        }
                    case 7:
                        {
                            BuscarPersonaPorDNI();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("\nMuchas gracias por utilizar nuestro sistema.");
                            salir = true;
                            break;
                        }
                }
                
            }
        }

        private void IngresarPersona(List<Vacuna> vacunasRegistradas)
        {
            Persona nuevaPersona = this.personaIO.IngresarPersona(centroVacunatorio);
            this.centroVacunatorio.RegistrarPersona(nuevaPersona);
        }

        private void ListarPersonas()
        {
            this.personaIO.ListarPersonas(this.centroVacunatorio.Personas);
        }

        private void BuscarPersonaPorDNI()
        {
            personaIO.BuscarPersonasPorDNI(centroVacunatorio.Personas);
        }

        private void IngresarVacuna()
        {
            Vacuna nuevaVacuna = this.vacunaIO.IngresarVacuna();
            this.centroVacunatorio.RegistrarVacuna(nuevaVacuna);
        }

        private void ListarVacuna()
        {
            this.vacunaIO.ListarVacunas(this.centroVacunatorio.Vacunas);
        }
       
        private void DosisSegunTipoDeVacuna()
        {
            List<Vacunacion> vacunacionesTotales = centroVacunatorio.Personas.SelectMany(x => x.Vacunaciones).ToList();
            Dictionary<Vacuna,int> vacunasPorTipo = vacunacionIO.VacunasPorTipo(centroVacunatorio.Vacunas,vacunacionesTotales);

            Console.Clear();
            foreach(KeyValuePair<Vacuna, int> vacuna in vacunasPorTipo)
            {
                Console.WriteLine($"{vacuna.Key.Nombre} - Dosis Aplicadas: {vacuna.Value}");
            }
            Console.ReadKey();
        }

        private int LeerOpcionValida(List<int> opcionesValidas)
        {
            bool aux = false;
            while (!aux) { 
                try 
                { 
                    int seleccionada = -1;
                    while (!opcionesValidas.Contains(seleccionada))
                    {
                        seleccionada = int.Parse(Console.ReadKey(true).KeyChar.ToString());
                    }
                    aux = true;
                    return seleccionada;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Por favor seleccione una opcion valida");
                }
            }
            return -1;
        }
    }
}
