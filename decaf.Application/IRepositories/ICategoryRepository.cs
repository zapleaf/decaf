using decaf.Domain.Entities;

namespace decaf.Application.IRepositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<List<Category>> GetAllWithChildren();
    Task<Category> GetByIdWithChildren(int id);
}
