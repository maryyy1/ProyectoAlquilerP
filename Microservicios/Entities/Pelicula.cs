namespace Microservicios.Entities
{
    public class Pelicula
    {
        public Guid PelId { get; set; }
        public string PelNombre { get; set;}
        public string PelImagen { get; set;}
        public double PelPrecio { get; set;}
        public int PelDuracion { get; set;}
        public int PelEstado { get; set; }
        public string PelSinopsis { get; set; }
        public string PelDirId { get; set; }
        public Director Director { get; set; }
        public string PelGenId { get; set; }
        public Genero Genero { get; set; }
        public string PelCatId { get; set; }
        public Categorias Categoria { get; set; }



    }
}
