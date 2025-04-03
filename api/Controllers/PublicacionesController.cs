using api.Models;
using api.Services;
using api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v1/productos")]
    public class PublicacionesController : ControllerBase
    {
        private PublicacionService Service;

        public PublicacionesController(PublicacionService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Publicaciones obtenidas satisfactoriamente.",
                Content = await Service.ObtenerTodos()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Publicacion publicacion)
        {
            try
            {
                Publicacion p = await Service.Crear(publicacion);

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
                    Message = "Publicacion creada satisfactoriamente",
                    Content = p 
                });
            }
            catch
            {
                return BadRequest(new Response
                {
                    Status = 400,
                    Message = "No se pudo crear la publicacion con los datos proporcionados.",
                    Content = null
                });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Modificar([FromRoute] int id, [FromBody] Publicacion p)
        {
            try
            {
                Publicacion pExistente = await Service.Modificar(id, p);

                if (pExistente == null)
                {
                    return NotFound(new Response
                    {
                        Status = 404,
                        Message = "Publicacion no existe.",
                        Content = null
                    });
                }
                return Ok(new Response
                {
                    Status = 200,
                    Message = "Publicacion modificada de forma satisfactoria.",
                    Content = pExistente
                });
            }
            catch
            {
                return BadRequest(new Response
                {
                    Status = 400,
                    Message = "No se pudo modificar la publicacion con los datos proporcionados.",
                    Content = null
                });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute] int id)
        {
            try
            {
                Publicacion p = await Service.ObtenerPorId(id);

                if (p == null)
                {
                    return NotFound(new Response
                    {
                        Status = 404,
                        Message = "Publicacion no existe",
                        Content = null
                    });
                }
                return Ok(new Response
                {
                    Status = 200,
                    Message = "Publicacion obtenido.",
                    Content = p
                });
            }
            catch
            {
                return NotFound(new Response
                {
                    Status = 404,
                    Message = "Publicacion no existe.",
                    Content = null
                });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            try
            {
                Publicacion p = await Service.ObtenerPorId(id);

                if (p == null)
                {
                    return NotFound(new Response
                    {
                        Status = 404,
                        Message = "Publicacion no existe",
                        Content = null
                    });
                }
                await Service.Eliminar(id);
                return Ok(new Response
                {
                    Status = 200,
                    Message = "Publicacion eliminada satisfactoriamente.",
                    Content = p
                });
            }
            catch
            {
                return NotFound(new Response
                {
                    Status = 404,
                    Message = "Publicacion no existe.",
                    Content = null
                });
            }
        }
    }
}
