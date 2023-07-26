using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticePeli.DTOs;
using PracticePeli.Entity;

namespace PracticePeli.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(
            ApplicationDbContext context,
            IMapper mapper
            )
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get()
        {
            var actores = await context.Actores.ToListAsync();
            return mapper.Map<List<ActorDTO>>(actores);
        }


        [HttpGet("{id:int}", Name = "obtenerActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var actor = await context.Actores.FirstOrDefaultAsync(actorDB => actorDB.Id == id);
            return mapper.Map<ActorDTO>(actor);
        }

        [HttpPost]  
        public async Task<ActionResult> Post([FromBody] ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var actorDTO = mapper.Map<ActorDTO>(entidad);
            return new CreatedAtRouteResult("obtenerActor", new {id = actorDTO.Id}, actorDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = await context.Actores.FirstOrDefaultAsync(actorDB => actorDB.Id == id);
            if (entidad == null)
            {
                return NotFound($"No se encuenta un actor con id {id} solicitado");
            }

            var actorUpdated = mapper.Map<Actor>(actorCreacionDTO);
            actorUpdated.Id = id;
            context.Entry(actorUpdated).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entidad = await context.Actores.FirstOrDefaultAsync(actorDB => actorDB.Id == id);
            if (entidad == null)
            {
                return NotFound($"No se encuenta un genero con id {id} solicitado]");
            }

            context.Remove(new Actor() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();

        }
    }
}
