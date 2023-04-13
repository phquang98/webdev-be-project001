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

        public ReviewController(IReviewRepo reviewRepoHere, IMapper mapperHere)
        {
            _reviewRepo = reviewRepoHere;
            _mapper = mapperHere;
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
    }
}
