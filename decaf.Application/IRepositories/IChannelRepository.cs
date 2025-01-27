using decaf.Domain.Entities;

namespace decaf.Application.IRepositories;

public interface IChannelRepository : IRepository<Channel>
{
    Task<Channel> Create(Channel channel);
    Task<IEnumerable<Channel>> GetWithCategories();
    Task<IEnumerable<Channel>> GetWithCategoriesAndVideos();
    Task<IEnumerable<Channel>> GetByCategory(int categoryId);
    Task<Channel> Get(int id);
    Task<Channel> Get(string YTID);
    Task<Channel> Update(Channel channel);
    Task<bool> AddCategoryToChannel(int categoryId, int channelId);
    Task<bool> RemoveCategoryFromChannel(int categoryId, int channelId);
    Task<bool> Delete(int id);
}
