using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    class Informacion
    {
        public string Telefono { get; private set; }
        public string TelefonoDeContacto { get; private set; }

        public string Email { get; private set; }

        public Informacion(string telefono, string telefonoDeContacto, string email)
        {
            this.Telefono = telefono;
            this.TelefonoDeContacto = telefonoDeContacto;
            this.Email = email;
        }
    }
}
