using Microsoft.AspNetCore.Mvc;

using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepo _pokeRepo;

        public PokemonController(IPokemonRepo pokeRepo)
        {
            _pokeRepo = pokeRepo;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult CtrGetPokemonClt()
        {

            var pokeRes = _pokeRepo.GetPokemonClt();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokeRes);
        }

    }
}
