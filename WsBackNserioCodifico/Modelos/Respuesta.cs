namespace WsBackNserioCodifico.Modelos
{
    public class Respuesta
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

        public Respuesta() { } 

        public Respuesta(int codigo, string mensaje, string descripcion)
        {
            this.StatusCode = codigo;
            this.Message = mensaje;
            this.Description = descripcion;
        }
    }
}
