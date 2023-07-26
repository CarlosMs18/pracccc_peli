using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticePeli.DTOs;
using PracticePeli.Entity;

namespace PracticePeli.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(
            ApplicationDbContext context,
            IMapper mapper
            )
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            var generos = await context.Generos.ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);
        }


        [HttpGet("{id:int}", Name = "ObtenerGenero")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(generoDB => generoDB.Id == id);
            return mapper.Map<GeneroDTO>(genero);
        }


        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);

            context.Add(genero);
            await context.SaveChangesAsync();
            var generoDTO = mapper.Map<GeneroDTO>(genero);
            return new CreatedAtRouteResult("ObtenerGenero", new { id = generoDTO.Id }, generoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GeneroCreacionDTO generoCreacionDTO)
        {
            var entidad = await context.Generos.FirstOrDefaultAsync(generoDB => generoDB.Id == id);
            if (entidad == null)
            {
                return NotFound($"No se encuenta un genero con id {id} solicitado");
            }

            var generoUpdated = mapper.Map<Genero>(generoCreacionDTO);
            generoUpdated.Id = id;
            context.Entry(generoUpdated).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entidad = await context.Generos.FirstOrDefaultAsync(generoDB => generoDB.Id == id);
            if (entidad == null)
            {
                return NotFound($"No se encuenta un genero con id {id} solicitado]");
            }

            context.Remove(new Genero() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();

        }



    }
}
