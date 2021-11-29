using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroDeVacunacion.Entidades;

namespace CentroDeVacunacion
{
    class CentroVacunatorio
    {
        private List<Persona> Personas = new List<Persona>();

        public void RegistrarPersona(Persona persona)
        {
            this.Personas.Add(persona);
        }

        public List<Persona> ObtenerPersonas()
        {
            return this.Personas;
        }
    }
}
