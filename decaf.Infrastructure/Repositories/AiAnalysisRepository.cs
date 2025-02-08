using decaf.Domain.Entities;
using decaf.Infrastructure.Data;
using decaf.Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace decaf.Infrastructure.Repositories;

public class AiAnalysisRepository : Repository<AiAnalysis>, IAiAnalysisRepository
{
    private readonly AppDbContext _context;

    public AiAnalysisRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AiAnalysis>> GetByChannelId(int channelId)
    {
        return await _context.AiAnalyses
            .Where(a => a.ChannelId == channelId && !a.IsDeleted)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<AiAnalysis?> GetMostRecentByChannelId(int channelId)
    {
        return await _context.AiAnalyses
            .Where(a => a.ChannelId == channelId && !a.IsDeleted)
            .OrderByDescending(a => a.CreatedAt)
            .FirstOrDefaultAsync();
    }
}
