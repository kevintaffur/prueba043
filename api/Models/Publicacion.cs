namespace api.Models
{
    public class Publicacion
    {
        private static int contador = 1;
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }

        public Publicacion(string titulo, string contenido, DateTime fecha, int usuarioId)
        {
            Id = contador++;
            Titulo = titulo;
            Contenido = contenido;
            Fecha = fecha;
            UsuarioId = usuarioId;
        }
    }
}
