using api.Models;
using api.Services;
using api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class ComentariosController : ControllerBase
    {
        private ComentarioService Service;

        public ComentariosController(ComentarioService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Comentarios obtenidos satisfactoriamente.",
                Content = await Service.ObtenerTodos()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Comentario comentario)
        {
            try
            {
                Comentario p = await Service.Crear(comentario);

                if (p == null)
                {
                    return BadRequest(new Response
                    {
                        Status = 201,
                        Message = "Usuario no existe",
                        Content = null
                    });
                }

                return Created("", new Response
                {
                    Status = 201,
                    Message = "Comentario creado satisfactoriamente",
                    Content = await Service.Crear(comentario)
                });
            }
            catch
            {
                return BadRequest(new Response
                {
                    Status = 400,
                    Message = "No se pudo crear el comentario con los datos proporcionados.",
                    Content = null
                });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Modificar([FromRoute] int id, [FromBody] Comentario c)
        {
            try
            {
                Comentario cExistente = await Service.Modificar(id, c);

                if (cExistente == null)
                {
                    return NotFound(new Response
                    {
                        Status = 404,
                        Message = "Comentario no existe.",
                        Content = null
                    });
                }
                return Ok(new Response
                {
                    Status = 200,
                    Message = "Comentario modificado de forma satisfactoria.",
                    Content = cExistente
                });
            }
            catch
            {
                return BadRequest(new Response
                {
                    Status = 400,
                    Message = "No se pudo modificar el comentario con los datos proporcionados.",
                    Content = null
                });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute] int id)
        {
            try
            {
                Comentario c = await Service.ObtenerPorId(id);

                if (c == null)
                {
                    return NotFound(new Response
                    {
                        Status = 404,
                        Message = "Comentario no existe",
                        Content = null
                    });
                }
                return Ok(new Response
                {
                    Status = 200,
                    Message = "Comentario obtenido.",
                    Content = c
                });
            }
            catch
            {
                return NotFound(new Response
                {
                    Status = 404,
                    Message = "Comentario no existe.",
                    Content = null
                });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            try
            {
                Comentario c = await Service.ObtenerPorId(id);

                if (c == null)
                {
                    return NotFound(new Response
                    {
                        Status = 404,
                        Message = "Comentario no existe",
                        Content = null
                    });
                }
                await Service.Eliminar(id);
                return Ok(new Response
                {
                    Status = 200,
                    Message = "Comentario eliminada satisfactoriamente.",
                    Content = c
                });
            }
            catch
            {
                return NotFound(new Response
                {
                    Status = 404,
                    Message = "Comentario no existe.",
                    Content = null
                });
            }
        }
    }
}
