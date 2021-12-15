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
        private const string ARROBA = "@";
        private const string COM = ".com";
        public Informacion IngresarInformacion()
        {
            string telefono = "";
            string telefonoDeContacto = "";
            string email = "";
            bool aux = false;

            while (!aux) 
            { 
                try 
                { 
                    Console.Clear();
                    Console.WriteLine("Ingrese el Numero de Telefono o Celular");
                    telefono = Console.ReadLine();
                    Console.WriteLine("Ingrese un Numero de Telefono de un contacto de Emergencia");
                    telefonoDeContacto = Console.ReadLine();
                    email = IngresarEmail();
                    aux = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Ha ocurrido un error {ex.Message}");
                }
            }
            return new Informacion(telefono, telefonoDeContacto, email);
        }

        public string IngresarEmail()
        {
            string email = "";

            bool aux = false;

            while (!aux)
            {
                try
                {
                    Console.WriteLine("Ingrese un Email de contacto");
                    email = (Console.ReadLine());
                    if(email.Contains(InformacionIO.COM) && email.Contains(InformacionIO.ARROBA))
                    {
                        aux = true;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar una direccion de correo valida");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debe ingresar una direccion de correo valida");
                }
            }
            return email;
        }
    }
}
