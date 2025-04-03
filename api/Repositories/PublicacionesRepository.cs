using api.Models;

namespace api.Repositories
{
    public class PublicacionesRepository
    {
        private readonly List<Publicacion> _list;

        public PublicacionesRepository()
        {
            _list = new List<Publicacion>();
        }

        public async Task<Publicacion> Crear(Publicacion publicacion)
        {
            _list.Add(publicacion);

            Publicacion p = await ObtenerPorId(publicacion.Id);
            return p;
        }

        public async Task<Publicacion> Modificar(int id, Publicacion publicacion)
        {
            Publicacion p = _list.Find(p => p.Id == id);

            if (publicacion.Titulo != null)
            {
                p.Titulo = publicacion.Titulo;
            }
            if (publicacion.Contenido != null)
            {
                p.Contenido = publicacion.Contenido;
            }

            return p;
        }

        public async Task<Publicacion> ObtenerPorId(int id)
        {
            return _list.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Publicacion>> ObtenerTodos()
        {
            return _list;
        }

        public async Task Eliminar(int id)
        {
            Publicacion p = await ObtenerPorId(id);
            _list.Remove(p);
        }
    }
}
