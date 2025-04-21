using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]

    public class GenerosController: ControllerBase
    {
        private readonly IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio) 
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        [HttpGet("listado")]
        [HttpGet("/listado-generos")]
        [OutputCache]
        public List<Genero>Get() 
        {
            
            var generos = repositorio.ObtenerTodosLosGeneros();

            return generos;
        }

        [HttpGet("{id:int}")]
        [OutputCache]
        public async Task<ActionResult<Genero>> Get(int id) 
        {
            
            var genero = await repositorio.ObtenerPorId(id);
            
            if (genero is null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Genero genero)
        {
            var repositorio = new RepositorioEnMemoria();
            var yaExisteElGenero = repositorio.Existe(genero.Nombre);
            if (yaExisteElGenero) 
            {
                return BadRequest($"Ya existe un genero con el nombre {genero.Nombre}");
            }

            return Ok();
        }

        [HttpPut]
        public void PUT()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}
