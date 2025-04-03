namespace api.Models
{
    public class Comentario
    {
        private static int contador = 1;
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public int PublicacionId { get; set; }

        public Comentario(string contenido, DateTime fecha, int usuarioId, int publicacionId)
        {
            contador++;
            Contenido = contenido;
            Fecha = fecha;
            UsuarioId = usuarioId;
            PublicacionId = publicacionId;
        }
    }
}
