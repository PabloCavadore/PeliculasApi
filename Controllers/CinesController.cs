using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Utilidades;

namespace PeliculasAPI.Controllers
{
    [Route("api/cines")]
    [ApiController]
    public class CinesController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;
        private const string cacheTag = "cines";

        public CinesController(ApplicationDbContext context, IMapper mapper, IOutputCacheStore outputCacheStore)
            : base(context, mapper, outputCacheStore, cacheTag)
        {
            this.context = context;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
        }

        [HttpGet]
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<CineDTO>> Get([FromQuery] PaginacionDTO paginacion)
        {
            return await Get<Cine, CineDTO>(paginacion, ordenarPor: c => c.Nombre);
        }

        [HttpGet("{id:int}", Name = "ObtenerCinePorId")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<CineDTO>> Get(int id)
        {
            return await Get<Cine, CineDTO>(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CineCreacionDTO cineCreacionDTO)
        {
           return await Post<CineCreacionDTO, Cine, CineDTO>(cineCreacionDTO, "ObtenerCinePorId");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CineCreacionDTO cineCreacionDTO)
        {
            return await Put<CineCreacionDTO, Cine>(id, cineCreacionDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            return await Delete<Cine>(id);
        }

    }
}
