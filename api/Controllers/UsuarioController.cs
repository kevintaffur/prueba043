using api.Services;
using api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService Service;

        public UsuarioController(IUsuarioService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Usuarios obtenidos satisfactoriamente.",
                Content = await Service.ObtenerTodos()
            });
        }
    }
}
