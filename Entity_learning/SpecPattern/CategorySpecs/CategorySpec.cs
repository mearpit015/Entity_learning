using Entity_learning.Entities;

namespace Entity_learning.SpecPattern.CategorySpecs
{
    public class CategorySpec : ISpecification<Category>
    {
        private readonly int _id;
        private readonly string _name;

        public CategorySpec(int? id = null, string? name = null)
        {
            _id = id ?? 0;
            _name = name ?? string.Empty;
        }

        public IQueryable<Category> Apply(IQueryable<Category> query)
        {
            if (_id > 0)
                query = query.Where(c => c.Id == _id);

            if (!string.IsNullOrWhiteSpace(_name))
                query = query.Where(c => c.Name == _name);

            return query;
        }
    }
}
