using assignment_two.DTOs.Product;

namespace assignment_two.Services.Interfaces
{
    public interface IProductService
    {
        AddProductResponse Create(AddProductRequest createModel);
        IEnumerable<GetProductResponse> GetAll();
        GetProductResponse GetById(int id);
        UpdateProductResponse Update(int id, UpdateProductRequest updateModel);
        bool Delete(int id);
    }
}