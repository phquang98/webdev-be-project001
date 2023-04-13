﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webdev_be_project001.Dto;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _cateRepo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepo cateRepoHere, IMapper mapperHere)
        {
            _cateRepo = cateRepoHere;
            _mapper = mapperHere;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult CtrGetCategoryClt()
        {
            var cateRes = _mapper.Map<List<CategoryDto>>(_cateRepo.GetCategoryClt());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cateRes);
        }

        [HttpGet("{cateIdHere}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetPokemon(int cateIdHere)
        {
            if (!_cateRepo.CategoryExists(cateIdHere))
            {
                return NotFound();
            }

            var cateRes = _mapper.Map<CategoryDto>(_cateRepo.GetCategory(cateIdHere));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cateRes);
        }

        [HttpGet("pokemon/{cateIdHere}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult CtrGetPokemonCltByCategory(int cateIdHere)
        {
            var pokeCltRes = _mapper.Map<List<PokemonDto>>(
                _cateRepo.GetPokemonCltByCategory(cateIdHere)
            );

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokeCltRes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto cateDataHere)
        {
            if (cateDataHere == null)
            {
                return BadRequest(ModelState);
            }

            var cateSuspect = _cateRepo
                .GetCategoryClt()
                .Where(
                    cate =>
                        cate.NameColumn.Trim().ToLower() == cateDataHere.NameColumn.Trim().ToLower()
                )
                .FirstOrDefault();

            if (cateSuspect != null)
            {
                ModelState.AddModelError("", "Category already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cateModel = _mapper.Map<Category>(cateDataHere);

            if (!_cateRepo.CreateCategory(cateModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }
    }
}
