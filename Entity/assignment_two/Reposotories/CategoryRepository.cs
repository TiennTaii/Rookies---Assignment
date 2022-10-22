using assignment_two.Data;
using assignment_two.Models;
using assignment_two.Repositories;

namespace assignment_two.Reposotories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductDataContext context) : base(context)
        {
        }
    }
}