// AiSummaryRepository.cs (in Infrastructure/Repositories)
using decaf.Infrastructure.Data;
using decaf.Domain.Entities;
using decaf.Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace decaf.Infrastructure.Repositories;

public class AiSummaryRepository : Repository<AiSummary>, IAiSummaryRepository
{
    private readonly AppDbContext _context;

    public AiSummaryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AiSummary>> GetByVideoId(int videoId)
    {
        return await _context.AiSummaries
            .Where(s => s.VideoId == videoId && !s.IsDeleted)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();
    }

    public async Task<AiSummary?> GetMostRecentByVideoId(int videoId)
    {
        return await _context.AiSummaries
            .Where(s => s.VideoId == videoId && !s.IsDeleted)
            .OrderByDescending(s => s.CreatedAt)
            .FirstOrDefaultAsync();
    }
}