using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webdev_be_project001.Dto;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepo _pokeRepo;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepo pokeRepo, IMapper mapperHere)
        {
            _pokeRepo = pokeRepo;
            _mapper = mapperHere;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult CtrGetPokemonClt()
        {
            var pokeRes = _mapper.Map<List<PokemonDto>>(_pokeRepo.GetPokemonClt());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokeRes);
        }

        [HttpGet("{pokeIdHere}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetPokemon(int pokeIdHere)
        {
            if (!_pokeRepo.PokemonExists(pokeIdHere))
            {
                return NotFound();
            }

            var pokeRes = _mapper.Map<PokemonDto>(_pokeRepo.GetPokemon(pokeIdHere));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokeRes);
        }

        [HttpGet("{pokeIdHere}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetPokemonRating(int pokeIdHere)
        {
            if (!_pokeRepo.PokemonExists(pokeIdHere))
            {
                return NotFound();
            }

            var rating = _pokeRepo.GetPokemonRating(pokeIdHere);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rating);
        }
    }
}
