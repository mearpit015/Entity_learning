using Entity_learning.Domain;
using Entity_learning.Entities;
using Entity_learning.SpecPattern;

namespace Entity_learning.Repositories.Interface
{
    public interface ICategoryRepository
    {

        Task<int> AddAsync(CategoryRequest request);

        Task<bool> UpdateAsync(int id ,CategoryRequest request);

        Task<IEnumerable<Category>> GetAsync(ISpecification<Category>? spec = null);

        Task<IEnumerable<Category>> GetAsync(params ISpecification<Category>[] specs);

        Task<bool> DeleteAsync (int categoryId);
    }
}
