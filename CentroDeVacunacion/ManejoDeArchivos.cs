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
    class ManejoDeArchivos 
    {
        public void GuardarPeronas(List<Persona> personas)
        {
            string path = "persona.json";

            try
            {
                File.WriteAllText(path, JsonSerializer.Serialize(personas));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error {ex.Message}");
            }
        }

        public void AbrirPersonas()
        {
            string path = "persona.json";

            try
            {
                List<Persona> personas = JsonSerializer.Deserialize<List<Persona>>(File.ReadAllText(path));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error {ex.Message}");
            }
            
        }
    }

    

    
    
}
