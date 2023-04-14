using AutoMapper;

using webdev_be_project001.Dto;
using webdev_be_project001.Models;

namespace webdev_be_project001.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // can be written as `CreateMap<Owner, OwnerDTO>().ReverseMap();`
            // not tested yet
            CreateMap<Pokemon, PokemonDto>();   // READ
            CreateMap<PokemonDto, Pokemon>();   // CREATE, UPDATE, DELETE
            CreateMap<Category, CategoryDto>(); // READ
            CreateMap<CategoryDto, Category>(); // CREATE, UPDATE, DELETE
            CreateMap<Country, CountryDto>();   // READ
            CreateMap<CountryDto, Country>();   // CREATE, UPDATE, DELETE
            CreateMap<Owner, OwnerDto>();       // READ
            CreateMap<OwnerDto, Owner>();       // CREATE, UPDATE, DELETE
            CreateMap<Review, ReviewDto>();     // READ
            CreateMap<ReviewDto, Review>();     // CREATE, UPDATE, DELETE
            CreateMap<Reviewer, ReviewerDto>(); // READ
            CreateMap<ReviewerDto, Reviewer>(); // CREATE, UPDATE, DELETE

        }
    }
}
