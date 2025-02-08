using decaf.Domain.Entities;

namespace decaf.Application.IRepositories;

public interface IAiSummaryRepository : IRepository<AiSummary>
{
    Task<IEnumerable<AiSummary>> GetByVideoId(int videoId);
    Task<AiSummary?> GetMostRecentByVideoId(int videoId);
}