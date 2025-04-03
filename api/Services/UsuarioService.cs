using api.Dtos.Usuarios;
using api.Models;
using api.Repositories;
using api.Utils;

namespace api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private UsuarioRepository Repo;

        public UsuarioService(UsuarioRepository repo)
        {
            Repo = repo;
        }

        public async Task<Usuario> Crear(SignUpRequest request)
        {
            Usuario usuario = new Usuario(request.Username,
                                            request.Email,
                                            BCrypt.Net.BCrypt.HashPassword(request.Password));

            return await Repo.Crear(usuario);
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            Usuario usuario = await Repo.ObtenerPorId(id);

            if (usuario == null)
            {
                return null;
            }
            return usuario;
        }

        public async Task<Usuario> ObtenerPorUsername(string username)
        {
            Usuario usuario = await Repo.ObtenerPorUsername(username);

            if (usuario == null)
            {
                return null;
            }
            return usuario;
        }

        public async Task<List<UsuarioShowDto>> ObtenerTodos()
        {
            List<Usuario> usuarios = await Repo.Todos();

            List<UsuarioShowDto> us = new List<UsuarioShowDto>();

            foreach (Usuario u in usuarios)
            {
                us.Add(new UsuarioShowDto
                {
                    Email = u.Email,
                    Id = u.Id,
                    Username = u.Username,
                });
            }

            return us;
        }
    }
}
