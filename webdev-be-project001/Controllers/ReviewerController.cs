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
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepo _reviewerRepo;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepo reviewerRepoHere, IMapper mapperHere)
        {
            _reviewerRepo = reviewerRepoHere;
            _mapper = mapperHere;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult CtrGetReviewerClt()
        {
            var reviewerCltRes = _mapper.Map<List<ReviewerDto>>(_reviewerRepo.GetReviewerClt());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewerCltRes);
        }

        [HttpGet("{reviewerIdHere}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetReviewer(int reviewerIdHere)
        {
            if (!_reviewerRepo.ReviewerExists(reviewerIdHere))
            {
                return NotFound();
            }

            var reviewerRes = _mapper.Map<ReviewerDto>(_reviewerRepo.GetReviewer(reviewerIdHere));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewerRes);
        }

        [HttpGet("{reviewerIdHere}/reviews")]
        public IActionResult CtrGetReviewCltByReviewer(int reviewerIdHere)
        {
            if (!_reviewerRepo.ReviewerExists(reviewerIdHere))
            {
                return NotFound();
            }

            var reviewClt = _mapper.Map<List<ReviewDto>>(
                _reviewerRepo.GetReviewCltByReviewer(reviewerIdHere)
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
        public IActionResult CtrCreateReviewer([FromBody] ReviewerDto reviewerDataHere)
        {
            if (reviewerDataHere == null)
            {
                return BadRequest(ModelState);
            }

            var reviewerSuspect = _reviewerRepo
                .GetReviewerClt()
                .Where(
                    reviewer =>
                        reviewer.LastNameColumn.Trim().ToLower() == reviewerDataHere.LastNameColumn.Trim().ToLower()
                )
                .FirstOrDefault();

            if (reviewerSuspect != null)
            {
                ModelState.AddModelError("", "Reviewer already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewerModel = _mapper.Map<Reviewer>(reviewerDataHere);

            if (!_reviewerRepo.CreateReviewer(reviewerModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }

        [HttpPut("{reviewerIdHere}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult CtrUpdateReviewer(
            int reviewerIdHere,
            [FromBody] ReviewerDto reviewerDataHere
        )
        {
            if (reviewerDataHere == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewerIdHere != reviewerDataHere.IdColumn)
            {
                return BadRequest(ModelState);
            }

            if (!_reviewerRepo.ReviewerExists(reviewerIdHere))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewerModel = _mapper.Map<Reviewer>(reviewerDataHere);

            if (!_reviewerRepo.UpdateReviewer(reviewerModel))
            {
                ModelState.AddModelError("", "Something went wrong with updating reviewer!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{reviewerIdHere}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult CtrDeleteReviewer(int reviewerIdHere)
        {
            if (!_reviewerRepo.ReviewerExists(reviewerIdHere))
            {
                return NotFound();
            }

            var removeReviewer = _reviewerRepo.GetReviewer(reviewerIdHere);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_reviewerRepo.DeleteReviewer(removeReviewer))
            {
                ModelState.AddModelError("", "Something went wrong with deleting reviewer!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
