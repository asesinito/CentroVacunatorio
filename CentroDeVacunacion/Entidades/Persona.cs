using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    class Persona
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public string ClaseDni { get; private set; }

        public int Dni { get; private set; }
        public string Nacionalidad { get; private set; }
        public DateTime FechaDeNacimiento { get; private set; }
        public Direccion Direccion { get; private set; }
        public Informacion Informacion { get; private set; }

        public Persona (string nombre, string apellido, string claseDni, int dni, string nacionalidad, DateTime fechaDeNacimiento, Direccion direccion, Informacion informacion)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.ClaseDni = claseDni;
            this.Dni = dni;
            this.Nacionalidad = nacionalidad;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this.Direccion = direccion;
            this.Informacion = informacion;
        }
    }
}
