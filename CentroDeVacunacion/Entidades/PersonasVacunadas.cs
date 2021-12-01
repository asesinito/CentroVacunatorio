using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    class PersonasVacunadas
    {
        public Persona Persona { get; private set; }
        public Vacuna Vacuna { get; private set; }

        public string Dosis { get; private set; }

        public DateTime HoraDeVacunacion = DateTime.Now;

        public PersonasVacunadas(Persona persona, Vacuna vacuna, string dosis)
        {
            this.Persona = persona;
            this.Vacuna = vacuna;
            this.Dosis = dosis;
        }

        public PersonasVacunadas() { }
    }
}
