using assignment_two.Data;
using assignment_two.Models;
using assignment_two.Repositories;
using assignment_two.Reposotories.Interfaces;

namespace assignment_two.Reposotories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDataContext context) : base(context)
        {
        }
    }
}