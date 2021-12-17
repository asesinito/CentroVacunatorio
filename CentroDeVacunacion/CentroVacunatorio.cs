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
        public List<Persona> Personas
        {
            get
            {
                return manejoDeArchivosDePersonas.Leer();
            }
        }
        public List<Vacuna> Vacunas
        {
            get
            {
                return manejoDeArchivosDeVacunas.Leer();
            }
        }

        private ManejoDeArchivos<Persona> manejoDeArchivosDePersonas = new ManejoDeArchivos<Persona>("personas.json");
        private ManejoDeArchivos<Vacuna> manejoDeArchivosDeVacunas = new ManejoDeArchivos<Vacuna>("vacunas.json");


        public void RegistrarPersona(Persona persona)
        {
            Personas.Add(persona);
            manejoDeArchivosDePersonas.Guardar(Personas);
        }

        public void EliminarRegistroDePersona(Persona persona)
        {
            Personas.Remove(persona);
            manejoDeArchivosDePersonas.Guardar(Personas);
        }

        public void RegistrarVacuna(Vacuna vacuna)
        {
            Vacunas.Add(vacuna);
            manejoDeArchivosDeVacunas.Guardar(Vacunas);
        }
    }
}
