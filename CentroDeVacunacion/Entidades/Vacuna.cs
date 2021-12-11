using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    public class Vacuna
    {
        public string Nombre { get; private set; }

        public string PaisDeOrigen { get; private set; }

        public Vacuna(string nombre, string paisDeOrigen)
        {
            this.Nombre = nombre;
            this.PaisDeOrigen = paisDeOrigen;
        }
    }
}
   
