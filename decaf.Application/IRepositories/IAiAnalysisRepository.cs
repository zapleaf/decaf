using decaf.Domain.Entities;

namespace decaf.Application.IRepositories;

public interface IAiAnalysisRepository : IRepository<AiAnalysis>
{
    Task<IEnumerable<AiAnalysis>> GetByChannelId(int channelId);
    Task<AiAnalysis?> GetMostRecentByChannelId(int channelId);
}