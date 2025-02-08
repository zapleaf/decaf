using decaf.Domain.Entities;

namespace decaf.Application.IRepositories;

public interface IPromptVersionRepository : IRepository<PromptVersion>
{
    Task<PromptVersion?> GetByCodeAndVersion(string code, string version);
    Task<IEnumerable<PromptVersion>> GetLatestVersions();
    Task<PromptVersion?> GetLatestByCode(string code);
}
