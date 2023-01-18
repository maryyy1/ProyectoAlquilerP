using System.ComponentModel.DataAnnotations;

namespace Alquiler_Peliculas.Entities
{
    public class Director
    {
        public int IdDirector { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApePaterno { get; set; }
        [Required]
        public string ApeMaterno { get; set; }
        [Required]
        public int Sexo { get; set; }
    }
}
