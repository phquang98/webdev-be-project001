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
    }
}
