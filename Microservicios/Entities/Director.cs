namespace Microservicios.Entities
{
    public class Director
    {
        public Guid DirId { get; set; }
        public string DirNombre { get; set; }
        public string DirApePat { get; set;}
        public string DirApeMat { get; set;}
        public int DirSexo { get; set; }    
        public Sexo Sexo { get; set; }

    }
}
