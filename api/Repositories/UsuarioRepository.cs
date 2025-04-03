using api.Models;

namespace api.Repositories
{
    public class UsuarioRepository
    {
        private readonly List<Usuario> _list;

        public UsuarioRepository()
        {
            _list = new List<Usuario>();
        }

        public async Task<List<Usuario>> Todos()
        {
            return _list;
        }

        public async Task<Usuario> Crear(Usuario usuario)
        {
            _list.Add(usuario);

            return usuario;
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            return _list.Find(u => u.Id == id);
        }

        public async Task<Usuario> ObtenerPorUsername(string username)
        {
            return _list.Find(u => u.Username == username);
        }
    }
}
