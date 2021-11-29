using CentroDeVacunacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.ConsolaUI
{
    class InformacionIO
    {
        public Informacion IngresarInformacion()
        {
            string telefono, telefonoDeContacto, email;

            Console.Clear();
            Console.WriteLine("Ingrese el Numero de Telefono o Celular");
            telefono = Console.ReadLine();
            Console.WriteLine("Ingrese un Numero de Telefono de un contacto de Emergencia");
            telefonoDeContacto = Console.ReadLine();
            Console.WriteLine("Ingrese un Email de contacto");
            email = Console.ReadLine();

            return new Informacion(telefono, telefonoDeContacto, email);
        }
    }
}
