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
        private readonly ICountryRepo _ctryRepo;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepo ownerRepoHere, ICountryRepo ctrryRepoHere , IMapper mapperHere)
        {
            _ownerRepo = ownerRepoHere;
            _ctryRepo = ctrryRepoHere;
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

        // NOTE: create Owner must have Country
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int ownerIdHere,[FromBody] OwnerDto ownerDataHere)
        {
            if (ownerDataHere == null)
            {
                return BadRequest(ModelState);
            }

            var ownerSuspect = _ownerRepo
                .GetOwnerClt()
                .Where(
                    owner =>
                        owner.NameColumn.Trim().ToLower() == ownerDataHere.NameColumn.Trim().ToLower()
                )
                .FirstOrDefault();

            if (ownerSuspect != null)
            {
                ModelState.AddModelError("", "Owner already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ownerModel = _mapper.Map<Owner>(ownerDataHere);

            ownerModel.CountryColumn = _ctryRepo.GetCountry(ownerIdHere);

            if (!_ownerRepo.CreateOwner(ownerModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }

        [HttpPut("{ownerIdHere}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOwner(int ownerIdHere, [FromBody] OwnerDto ownerDataHere)
        {
            if (ownerDataHere == null)
            {
                return BadRequest(ModelState);
            }

            if (ownerIdHere != ownerDataHere.IdColumn)
            {
                return BadRequest(ModelState);
            }

            if (!_ownerRepo.OwnerExists(ownerIdHere))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ownerModel = _mapper.Map<Owner>(ownerDataHere);

            if (!_ownerRepo.UpdateCountry(ownerModel))
            {
                ModelState.AddModelError("", "Something went wrong with updating owner!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
