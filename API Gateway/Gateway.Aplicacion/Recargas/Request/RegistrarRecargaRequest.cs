namespace Gateway.Aplicacion.Recargas.Request
{
    public class RegistrarRecargaRequest
    {    
        public int RecId { get; set; }

        public string RecFecha { get; set; }

        public double RecMonto { get; set; }

        public int RecCliId { get; set; }
    }

}
