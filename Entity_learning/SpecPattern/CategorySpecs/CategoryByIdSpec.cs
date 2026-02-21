using Entity_learning.Entities;
using System.Security.Cryptography;

namespace Entity_learning.SpecPattern.CategorySpecs
{
    public class CategoryByIdSpec : ISpecification<Category>
    {
        private readonly int _id;
        public CategoryByIdSpec(int id) => _id = id;

        public IQueryable<Category> Apply(IQueryable<Category> query)
            => query.Where(c => c.Id == _id);

    }
}
