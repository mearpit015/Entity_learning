using Entity_learning.Domain;
using Entity_learning.Entities;
using Entity_learning.Entities.Contexts;
using Entity_learning.Repositories.Interface;
using Entity_learning.SpecPattern;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Entity_learning.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> _logger;
        private readonly TestEntityContext _context;
        public CategoryRepository(TestEntityContext context,
            ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> AddAsync(CategoryRequest request)
        {
            try
            {
                Category category = new Category
                {
                    Name = request.Name,
                    //CreatedDate= DateTime.Now,
                    Description = request.Description,
                    IsDeleted = true
                };

                var result = await _context.Categories.AddAsync(category);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            try
            {
                var getCategory = await _context.Categories.FirstOrDefaultAsync(opt => opt.Id == categoryId);
                if (getCategory is null)
                {
                    throw new InvalidOperationException("no category found.");
                }

                var result = _context.Categories.Remove(getCategory);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Category>> GetAsync(ISpecification<Category>? spec = null)
        {
            try
            {
                IQueryable<Category> query = _context.Categories
                                            .AsNoTracking()
                                            .AsQueryable();

                if (spec != null)
                    query = spec.Apply(query);

                return await query.ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(int id, CategoryRequest request)
        {
            try
            {
                // Direct SQL update, no entity tracking, faster for bulk operations. best for bulk updates
                //var result = await _context.Categories
                //                  .Where(c => c.Id == id)
                //                  .ExecuteUpdateAsync(setters => setters
                //                  .SetProperty(c => c.Description, request.Description)
                //                  .SetProperty(c => c.Name, request.Name));


                var getCategory = await _context.Categories.FirstOrDefaultAsync(opt => opt.Id == id);
                if (getCategory is null)
                {
                    throw new InvalidOperationException("no category found.");
                }

                if (!string.IsNullOrWhiteSpace(request.Description))
                {
                    getCategory.Description = request.Description;
                }

                getCategory.Name = request.Name;

                var result = await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
