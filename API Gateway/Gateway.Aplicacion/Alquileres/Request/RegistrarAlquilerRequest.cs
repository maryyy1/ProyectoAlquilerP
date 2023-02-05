using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Aplicacion.Alquileres.Request
{
    public class RegistrarAlquilerRequest
    {
        public int IdAlquiler { get; set; }        
        public int IdCliente { get; set; }
        public string AlqFecIni { get; set; }
        public string AlqFecFin { get; set; }
        public string AlqEnlace { get; set; }
        public int IdDetAl { get; set; }
        public int IdPelicula { get; set; }
    }

}
