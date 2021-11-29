using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeVacunacion.Entidades
{
    class Direccion
    {
        public string Ciudad { get; private set; }
        public string Provincia { get; private set; }
        public string CodigoPostal { get; private set; }
        public string Calle { get; private set; }
        public string Numero { get; private set; }
        public string Observacion { get; private set; }

        public Direccion(string ciudad, string provincia, string codigoPostal, string calle, string numero)
        {
            this.Ciudad = ciudad;
            this.Provincia = provincia;
            this.CodigoPostal = codigoPostal;
            this.Calle = calle;
            this.Numero = numero;
        }
    }
}
