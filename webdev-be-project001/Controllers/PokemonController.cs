using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webdev_be_project001.Dto;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;
using webdev_be_project001.Repositories;

namespace webdev_be_project001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepo _pokeRepo;
        private readonly IReviewerRepo _reviewRepo;
        private readonly IMapper _mapper;

        public PokemonController(
            IPokemonRepo pokeRepo,
            IReviewerRepo reviewRepo,
            IMapper mapperHere
        )
        {
            _pokeRepo = pokeRepo;
            _reviewRepo = reviewRepo;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon(
            [FromQuery] int ownerIdHere,
            [FromQuery] int cateIdHere,
            [FromBody] PokemonDto pokeDataHere
        )
        {
            if (pokeDataHere == null)
            {
                return BadRequest(ModelState);
            }

            var pokeSuspect = _pokeRepo
                .GetPokemonClt()
                .Where(
                    poke =>
                        poke.NameColumn.Trim().ToLower() == pokeDataHere.NameColumn.Trim().ToLower()
                )
                .FirstOrDefault();

            if (pokeSuspect != null)
            {
                ModelState.AddModelError("", "Pokemon already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokeModel = _mapper.Map<Pokemon>(pokeDataHere);

            if (!_pokeRepo.CreatePokemon(ownerIdHere, cateIdHere, pokeModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }

        [HttpPut("{pokeIdHere}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon(
            int pokeIdHere,
            [FromQuery] int ownerIdHere,
            [FromQuery] int cateIdHere,
            [FromBody] PokemonDto pokeDataHere
        )
        {
            if (pokeDataHere == null)
            {
                return BadRequest(ModelState);
            }

            if (pokeIdHere != pokeDataHere.IdColumn)
            {
                return BadRequest(ModelState);
            }

            if (!_pokeRepo.PokemonExists(pokeIdHere))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemonModel = _mapper.Map<Pokemon>(pokeDataHere);

            if (!_pokeRepo.UpdatePokemon(ownerIdHere, cateIdHere, pokemonModel))
            {
                ModelState.AddModelError("", "Something went wrong with updating pokemon!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
