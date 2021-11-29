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

        public PersonasVacunadas(Persona persona, Vacuna vacuna)
        {
            this.Persona = persona;
            this.Vacuna = vacuna;
        }

        public PersonasVacunadas() { }
    }
}
