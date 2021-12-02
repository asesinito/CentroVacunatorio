using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CentroDeVacunacion.Entidades;

namespace CentroDeVacunacion
{
    class CentroVacunatorio
    {
        private ManejoDeArchivos manejoDeArchivos = new ManejoDeArchivos();
        private List<Persona> Personas = new List<Persona>();
        private List<Vacuna> Vacunas = new List<Vacuna>();

        public void RegistrarPersona(Persona persona)
        {
            this.Personas.Add(persona);
            manejoDeArchivos.GuardarPeronas(Personas);
        }

        public List<Persona> ObtenerPersonas()
        {
            return this.Personas;
        }
        
        public void RegistrarVacuna(Vacuna vacuna)
        {
            this.Vacunas.Add(vacuna);
        }

        public List<Vacuna> ObtenerVacuna()
        {
            return this.Vacunas;
        }
    }
}
