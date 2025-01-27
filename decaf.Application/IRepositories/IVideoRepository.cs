using decaf.Domain.Entities;

namespace decaf.Application.IRepositories;

public interface IVideoRepository : IRepository<Video>
{
    Task<int> Create(List<Video> videos);
    Task<Video> Get(string ytid, bool includeStats = false);
    Task<IEnumerable<Video>> GetByChannel(string ytChannelID);
    Task<IEnumerable<Video>> GetByChannel(int channelID);
    Task<IEnumerable<Video>> GetByCategory(int categoryId);
    Task<int> Update(List<Video> videos);
}
