using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    class Vacunacion
    {
       public Vacuna Vacuna { get; private set; }
        public int Dosis { get; private set; }

        public DateTime FechaYHoraDeVacunacion { get; private set; }

        public Vacunacion(Vacuna vacuna, int dosis, DateTime fechaYHoraDeVacunacion)
        {
            this.Vacuna = vacuna;
            this.Dosis = dosis;
            this.FechaYHoraDeVacunacion = fechaYHoraDeVacunacion;
        }

        public static Vacunacion EstadoDeVacunacionPorDefecto()
        {
            return new Vacunacion(new Vacuna(string.Empty, string.Empty), -1, new DateTime());
        }
    }
}
