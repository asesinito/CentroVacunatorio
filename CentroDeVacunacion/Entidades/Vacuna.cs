using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    class Vacuna
    {
        public string Nombre { get; private set; }
        public string Dosis { get; private set; }

        public DateTime Hora { get; private set; }

        public Vacuna(string nombre, string dosis, DateTime hora)
        {
            this.Nombre = nombre;
            this.Dosis = dosis;
            this.Hora = hora;
        }
    }
}
