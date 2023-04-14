using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webdev_be_project001.Dto;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepo _reviewRepo;
        private readonly IMapper _mapper;
        private readonly IPokemonRepo _pokeRepo;
        private readonly IReviewerRepo _reviewerRepo;

        public ReviewController(
            IReviewRepo reviewRepoHere,
            IMapper mapperHere,
            IPokemonRepo pokeRepoHere,
            IReviewerRepo reviewerRepoHere
        )
        {
            _reviewRepo = reviewRepoHere;
            _mapper = mapperHere;
            _pokeRepo = pokeRepoHere;
            _reviewerRepo = reviewerRepoHere;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult CtrGetReviewClt()
        {
            var reviewCltRes = _mapper.Map<List<ReviewDto>>(_reviewRepo.GetReviewClt());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewCltRes);
        }

        [HttpGet("{reviewIdHere}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetReview(int reviewIdHere)
        {
            if (!_reviewRepo.ReviewExists(reviewIdHere))
            {
                return NotFound();
            }

            var reviewRes = _mapper.Map<ReviewDto>(_reviewRepo.GetReview(reviewIdHere));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewRes);
        }

        [HttpGet("pokemon/{pokeIdHere}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetReviewCltOfAPokemon(int pokeIdHere)
        {
            var reviewClt = _mapper.Map<List<ReviewDto>>(
                _reviewRepo.GetReviewCltOfAPokemon(pokeIdHere)
            );

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewClt);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview(
            [FromQuery] int reviewerIdHere,
            [FromQuery] int pokeIdHere,
            [FromBody] ReviewDto reviewDataHere
        )
        {
            if (reviewDataHere == null)
            {
                return BadRequest(ModelState);
            }

            var reviewSuspect = _reviewRepo
                .GetReviewClt()
                .Where(
                    poke =>
                        poke.TitleColumn.Trim().ToLower()
                        == reviewDataHere.TitleColumn.Trim().ToLower()
                )
                .FirstOrDefault();

            if (reviewSuspect != null)
            {
                ModelState.AddModelError("", "Review already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewModel = _mapper.Map<Review>(reviewDataHere);

            reviewModel.PokemonColumn = _pokeRepo.GetPokemon(pokeIdHere);
            reviewModel.ReviewerColumn = _reviewerRepo.GetReviewer(reviewerIdHere);


            if (!_reviewRepo.CreaateReview(reviewModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }
    }
}
