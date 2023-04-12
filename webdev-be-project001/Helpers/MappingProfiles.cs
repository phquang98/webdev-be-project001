using AutoMapper;

using webdev_be_project001.Dto;
using webdev_be_project001.Models;

namespace webdev_be_project001.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles() {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
