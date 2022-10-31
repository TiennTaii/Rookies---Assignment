using assignment_two.DTOs.Category;
using assignment_two.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace assignment_two.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public AddCategoryResponse? Add([FromBody] AddCategoryRequest addCategoryRequest)
        {
            return _categoryService.Create(addCategoryRequest);
        }

        [HttpGet]
        public IEnumerable<GetCategoryResponse> GetAll()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("{id}")]
        public GetCategoryResponse? GetById(int id)
        {
            return _categoryService.GetById(id);
        }

        [HttpPut("{id}")]
        public UpdateCategoryResponse? Update(int id, [FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            return _categoryService.Update(id, updateCategoryRequest);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _categoryService.Delete(id);
        }
    }
}