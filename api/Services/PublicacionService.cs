using api.Models;
using api.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class PublicacionService
    {
        private readonly PublicacionesRepository Repo;
        private readonly IUsuarioService UsuarioService;
        private readonly ComentarioRepository comentarioRepository;

        public PublicacionService(PublicacionesRepository repo, IUsuarioService usuarioService, ComentarioRepository comentarioService)
        {
            Repo = repo;
            UsuarioService = usuarioService;
            comentarioRepository = comentarioService;
        }

        public async Task<Publicacion> Crear(Publicacion p)
        {
            Usuario usuario = await UsuarioService.ObtenerPorId(p.UsuarioId);

            if (usuario == null)
            {
                return null;
            }

            Publicacion publicacion = new Publicacion(p.Titulo,
                                                        p.Contenido,
                                                        p.Fecha,
                                                        p.UsuarioId);

            return await Repo.Crear(publicacion);
        }

        public async Task<Publicacion> Modificar(int id, Publicacion p)
        {
            Publicacion pExistente = await Repo.Modificar(id, p);

            return pExistente;
        }

        public async Task<Publicacion> ObtenerPorId(int id)
        {
            Publicacion publicacion = await Repo.ObtenerPorId(id);

            if (publicacion == null)
            {
                return null;
            }

            return publicacion;
        }

        public async Task<List<Publicacion>> ObtenerTodos()
        {
            return await Repo.ObtenerTodos();
        }

        public async Task Eliminar(int id)
        {
            List<Comentario> comentarios = await comentarioRepository.ObtenerPorPublicacionId(id);

            if (!comentarios.IsNullOrEmpty())
            {
                throw new Exception("Publicación tiene comentarios asociados.");
            }

            await Repo.Eliminar(id);
        }
    }
}
