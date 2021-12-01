using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    class PersonaVacunada
    {
        public Persona Persona { get; private set; }
        public Vacuna Vacuna { get; private set; }

        public int Dosis { get; private set; }

        public DateTime FechaYHoraDeVacunacion = DateTime.Now;

        public PersonaVacunada(Persona persona, Vacuna vacuna, int dosis)
        {
            this.Persona = persona;
            this.Vacuna = vacuna;
            this.Dosis = dosis;
        }

        public PersonaVacunada() { }
    }
}
