using Azure.Core;
using Entity_learning.Domain;
using Entity_learning.Entities;
using Entity_learning.Repositories.Interface;
using Entity_learning.SpecPattern;
using Entity_learning.SpecPattern.CategorySpecs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Entity_learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ILogger<CategoryController> logger,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Get all
                var allCategories = await _categoryRepository.GetAsync();

                return Ok(allCategories);
            }
            catch
            {

                throw;
            }
        }

        //// GET api/<CategoryController>/5
        [HttpGet("GetCategory")]
        public async Task<IActionResult> Get([FromQuery]int? id, [FromQuery] string? name)
        {
            try
            {
                // Get by Id
                var category = await _categoryRepository.GetAsync(new CategorySpec(id, name));

                return Ok(category.FirstOrDefault());
            }
            catch
            {

                throw;
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryRequest request)
        {
            try
            {
                var result = await _categoryRepository.AddAsync(request);
                return Accepted(result);
            }
            catch
            {
                throw;
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([Required] int id, [FromBody] CategoryRequest request)
        {
            try
            {
                return Accepted(await _categoryRepository.UpdateAsync(id, request));
            }
            catch
            {

                throw;
            }
        }

        //// DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Accepted(await _categoryRepository.DeleteAsync(id));
            }
            catch
            {

                throw;
            }

        }
    }
}
