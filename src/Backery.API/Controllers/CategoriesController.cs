using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
		       //TODO:ErrValid

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);   

            if (!result.Success)
		       //TODO:ErrValid

	        var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
	        return Ok(categoryResource); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
	        if (!ModelState.IsValid)
		         //TODO:ErrValid

	        var category = _mapper.Map<SaveCategoryResource, Category>(resource);
	        var result = await _categoryService.UpdateAsync(id, category);

	        if (!result.Success)
		        //TODO:ErrValid

	        var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
	        return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
	        var result = await _categoryService.DeleteAsync(id);

	        if (!result.Success)
		        //TODO:ErrValid

	        var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
	             return Ok(categoryResource);
        }
    }
}