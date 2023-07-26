using AutoMapper;
using PracticePeli.DTOs;
using PracticePeli.Entity;

namespace PracticePeli.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles() {

            CreateMap<Genero , GeneroDTO>();

            CreateMap<GeneroCreacionDTO, Genero>();


            CreateMap<ActorCreacionDTO, Actor>();

            CreateMap<Actor, ActorDTO>();   
        }
    }
}
