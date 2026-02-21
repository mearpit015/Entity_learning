using Entity_learning.Entities;

namespace Entity_learning.SpecPattern.CategorySpecs
{
    public class CategoryByNameSpec : ISpecification<Category>
    {
        private readonly string _name;

        public CategoryByNameSpec(string name)
        {
            _name = name;
        }

        public IQueryable<Category> Apply(IQueryable<Category> query)
        {
           return query.Where(x => x.Name.Equals(_name));
        }
    }
}
