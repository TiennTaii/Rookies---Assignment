using assignment_two.DTOs.Category;

namespace assignment_two.Services.Interfaces
{
    public interface ICategoryService
    {
        AddCategoryResponse Create(AddCategoryRequest createModel);
        IEnumerable<GetCategoryResponse> GetAll();
        GetCategoryResponse GetById(int id);
        UpdateCategoryResponse Update(int id, UpdateCategoryRequest updateModel);
        bool Delete(int id);
    }
}