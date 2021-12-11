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

        public void MenuPrincipal()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();

                Console.WriteLine("Centro de Vacunacion COIVD-19");
                Console.WriteLine("1. Registrar Persona");
                Console.WriteLine("2. Registrar Aplicacion de Vacuna");
                Console.WriteLine("3. Ver registro de Personas Ingresadas");
                Console.WriteLine("4. Ingresar Vacuna al registro");
                Console.WriteLine("5. Ver Vacunas ingresadas");
                Console.WriteLine("0. Salir");

                int opcion = this.LeerOpcionValida(new List<int>() { 1, 2, 3, 4, 5, 0 });

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
                    case 0:
                        {
                            Console.WriteLine("Adios!");
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

        private void IngresarVacuna()
        {
            Vacuna nuevaVacuna = this.vacunaIO.IngresarVacuna();
            this.centroVacunatorio.RegistrarVacuna(nuevaVacuna);
        }

        private void ListarVacuna()
        {
            this.vacunaIO.ListarVacunas(this.centroVacunatorio.Vacunas);
        }

        private int LeerOpcionValida(List<int> opcionesValidas)
        {
            int seleccionada = -1;
            while (!opcionesValidas.Contains(seleccionada))
            {
                seleccionada = int.Parse(Console.ReadKey(true).KeyChar.ToString());
            }
            return seleccionada;
        }
    }
}
