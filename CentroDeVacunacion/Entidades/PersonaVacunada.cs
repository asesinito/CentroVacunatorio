using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    class PersonaVacunada:Persona
    {
        public Vacuna Vacuna { get; private set; }
        public int Dosis { get; private set; }

        public DateTime FechaYHoraDeVacunacion;

        public PersonaVacunada(string nombre, string apellido, string claseDni, int dni, string nacionalidad, DateTime fechaDeNacimiento, Direccion direccion, Informacion informacion, Vacuna vacuna, int dosis)
            :base(nombre, apellido, claseDni, dni, nacionalidad, fechaDeNacimiento, direccion, informacion)
        {
            this.Vacuna = vacuna;
            this.Dosis = dosis;
            FechaYHoraDeVacunacion = DateTime.Now;
        }
    }
}
