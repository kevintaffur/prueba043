using api.Models;
using api.Repositories;

namespace api.Services
{
    public class ComentarioService
    {
        private readonly ComentarioRepository Repo;
        private readonly IUsuarioService UsuarioService;
        private readonly PublicacionService PublicacionService;

        public ComentarioService(ComentarioRepository repo, IUsuarioService usuarioService, PublicacionService publicacionService)
        {
            Repo = repo;
            UsuarioService = usuarioService;
            PublicacionService = publicacionService;
        }

        public async Task<Comentario> Crear(Comentario comentario)
        {
            Usuario usuario = await UsuarioService.ObtenerPorId(comentario.UsuarioId);

            if (usuario == null)
            {
                return null;
            }

            Publicacion p = await PublicacionService.ObtenerPorId(comentario.PublicacionId);

            if (p == null)
            {
                return null;
            }

            Comentario com = new Comentario(comentario.Contenido,
                                          comentario.Fecha,
                                          comentario.UsuarioId,
                                          comentario.PublicacionId);

            return await Repo.Crear(comentario);
        }

        public async Task<Comentario> Modificar(int id, Comentario p)
        {
            Comentario cExistente = await Repo.Modificar(id, p);

            return cExistente;
        }

        public async Task<Comentario> ObtenerPorId(int id)
        {
            Comentario comentario = await Repo.ObtenerPorId(id);

            if (comentario == null)
            {
                return null;
            }

            return comentario;
        }

        public async Task<List<Comentario>> ObtenerTodos()
        {
            return await Repo.ObtenerTodos();
        }

        public async Task Eliminar(int id)
        {
            await Repo.Eliminar(id);
        }
    }
}
