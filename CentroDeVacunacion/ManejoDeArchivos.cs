using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using CentroDeVacunacion.Entidades;

namespace CentroDeVacunacion
{
    class ManejoDeArchivos<T>
    {
        private string path;
        private List<T> datos = new List<T>();
        private bool necesitaRecargar = true;

        public ManejoDeArchivos(string path)
        {
            this.path = path;
        }

        public void Guardar(List<T> datos)
        {
            try
            {
                File.WriteAllText(path, JsonSerializer.Serialize(datos));
                necesitaRecargar = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error {ex.Message}");
            }
        }

        public List<T> Leer()
        {
            if (necesitaRecargar) { 
                try
                {
                    datos = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path));
                    necesitaRecargar = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ha ocurrido un error {ex.Message}");
                }
            }
            return datos;
        }
    }
}
