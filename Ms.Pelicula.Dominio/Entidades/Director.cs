using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ms.Pelicula.Dominio.Entidades
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
