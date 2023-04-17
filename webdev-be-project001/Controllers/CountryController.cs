using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webdev_be_project001.Dto;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepo _ctryRepo;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepo ctryRepoHere, IMapper mapperHere)
        {
            _ctryRepo = ctryRepoHere;
            _mapper = mapperHere;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult CtrGetCountryClt()
        {
            var ctryCltRes = _mapper.Map<List<CountryDto>>(_ctryRepo.GetCountryClt());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ctryCltRes);
        }

        [HttpGet("{ctryIdHere}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetCtry(int ctryIdHere)
        {
            if (!_ctryRepo.CountryExists(ctryIdHere))
            {
                return NotFound();
            }

            var ctryRes = _mapper.Map<CountryDto>(_ctryRepo.GetCountry(ctryIdHere));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ctryRes);
        }

        [HttpGet("owners/{ownerIdHere}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetCtryOfTheOwner(int ownerIdHere)
        {
            var ctryRes = _mapper.Map<CountryDto>(_ctryRepo.GetCountryByOwner(ownerIdHere));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ctryRes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto ctryDataHere)
        {
            if (ctryDataHere == null)
            {
                return BadRequest(ModelState);
            }

            var ctrySuspect = _ctryRepo
                .GetCountryClt()
                .Where(
                    cate =>
                        cate.NameColumn.Trim().ToLower() == ctryDataHere.NameColumn.Trim().ToLower()
                )
                .FirstOrDefault();

            if (ctrySuspect != null)
            {
                ModelState.AddModelError("", "Country already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ctryModel = _mapper.Map<Country>(ctryDataHere);

            if (!_ctryRepo.CreateCountry(ctryModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }

        [HttpPut("{ctryIdHere}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCountry(int ctryIdHere, [FromBody] CountryDto ctryDataHere)
        {
            if (ctryDataHere == null)
            {
                return BadRequest(ModelState);
            }

            if (ctryIdHere != ctryDataHere.IdColumn)
            {
                return BadRequest(ModelState);
            }

            if (!_ctryRepo.CountryExists(ctryIdHere))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ctryModel = _mapper.Map<Country>(ctryDataHere);

            if (!_ctryRepo.UpdateCountry(ctryModel))
            {
                ModelState.AddModelError("", "Something went wrong with updating country!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
