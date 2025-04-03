using api.Models;

namespace api.Repositories
{
    public class ComentarioRepository
    {
        private readonly List<Comentario> _list;

        public ComentarioRepository()
        {
            _list = new List<Comentario>();
        }

        public async Task<Comentario> Crear(Comentario comentario)
        {
            _list.Add(comentario);

            Comentario p = await ObtenerPorId(comentario.Id);
            return p;
        }

        public async Task<Comentario> ObtenerPorId(int id)
        {
            return _list.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Comentario>> ObtenerTodos()
        {
            return _list;
        }

        public async Task<Comentario> Modificar(int id, Comentario comentario)
        {
            Comentario c = _list.Find(p => p.Id == id);

            if (comentario.Contenido != null)
            {
                c.Contenido = comentario.Contenido;
            }
            c.Fecha = DateTime.Now;

            return c;
        }

        public async Task Eliminar(int id)
        {
            Comentario cExistente = await ObtenerPorId(id);
            _list.Remove(cExistente);
        }
    }
}
