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

        public void MenuPrincipal()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();

                Console.WriteLine("Centro de Vacunacion COIVD-19");
                Console.WriteLine("1. Registrar Persona");
                Console.WriteLine("2. Registrar Vacunacion");
                Console.WriteLine("3. Ver registro de Personas Ingresadas");
                Console.WriteLine("4. Ver Vacunas ingresadas");
                Console.WriteLine("0. Salir");

                int opcion = this.LeerOpcionValida(new List<int>() { 1, 2, 3, 4, 0 });

                switch (opcion)
                {
                    case 1:
                        {
                            this.IngresarPersona();
                            break;
                        }
                    case 2:
                        {
                            this.IngresarPersona();
                            break;
                        }
                    case 3:
                        {
                            this.ListarPersonas();
                            break;
                        }
                    case 4:
                        {
                            this.IngresarPersona();
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

        private void IngresarPersona()
        {
            Persona nuevaPersona = this.personaIO.IngresarPersona();
            this.centroVacunatorio.RegistrarPersona(nuevaPersona);
        }

        private void ListarPersonas()
        {
            this.personaIO.ListarPersonas(this.centroVacunatorio.ObtenerPersonas());
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
