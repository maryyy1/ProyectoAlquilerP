using System.ComponentModel.DataAnnotations;

namespace Alquiler_Peliculas.Entities
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Duracion { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public Director Director { get; set; }
    }
}
