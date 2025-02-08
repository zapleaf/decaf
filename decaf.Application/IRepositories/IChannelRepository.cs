using decaf.Domain.Entities;

namespace decaf.Application.IRepositories;

public interface IChannelRepository : IRepository<Channel>
{
    Task<IEnumerable<Channel>> GetWithCategories();
    Task<IEnumerable<Channel>> GetWithCategoriesAndVideos();
    Task<IEnumerable<Channel>> GetByCategory(int categoryId);
    Task<Channel> Get(string YTID);
    Task<bool> AddCategoryToChannel(int categoryId, int channelId);
    Task<bool> RemoveCategoryFromChannel(int categoryId, int channelId);
}
