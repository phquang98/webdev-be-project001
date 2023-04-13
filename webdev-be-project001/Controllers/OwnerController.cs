using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webdev_be_project001.Dto;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepo _ownerRepo;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepo ownerRepoHere, IMapper mapperHere)
        {
            _ownerRepo = ownerRepoHere;
            _mapper = mapperHere;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult CtrGetOwnerClt()
        {
            var ownerCltRes = _mapper.Map<List<OwnerDto>>(_ownerRepo.GetOwnerClt());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ownerCltRes);
        }

        [HttpGet("{ownerIdHere}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetOwner(int ownerIdHere)
        {
            if (!_ownerRepo.OwnerExists(ownerIdHere))
            {
                return NotFound();
            }

            var ownerRes = _mapper.Map<OwnerDto>(_ownerRepo.GetOwner(ownerIdHere));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ownerRes);
        }

        [HttpGet("{ownerIdHere}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetPokemonByOwner(int ownerIdHere)
        {
            if (!_ownerRepo.OwnerExists(ownerIdHere))
            {
                return NotFound(ModelState);
            }

            var pokeClt = _mapper.Map<List<PokemonDto>>(_ownerRepo.GetPokemonByOwner(ownerIdHere));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokeClt);
        }
    }
}
