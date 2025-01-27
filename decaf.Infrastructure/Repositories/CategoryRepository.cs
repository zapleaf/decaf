using decaf.Infrastructure.Data;
using decaf.Domain.Entities;
using decaf.Application.IRepositories;

namespace decaf.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Category> GetByIdWithChildren(int id)
    {
        return await Get(id, c => c.Channels);
    }

    public async Task<List<Category>> GetAllWithChildren()
    {
        return await GetAll(c => c.Channels);
    }
}
