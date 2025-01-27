using decaf.Application.Channels.Common;
using decaf.Domain.Entities;

namespace decaf.Application.IServices;

public interface IYouTubeApiService
{
    Task<List<ChannelDto>> ChannelSearch(string searchTerm);
    Task<Channel> GetChannelStats(string youTubeId);
    Task<Video> GetStats(Video video);
    Task<int?> GetDuration(string youTubeId);
    Task<List<Video>> GetChannelVideos(string channelId, DateTime? since = null);
    Task<List<Video>> VideoSearch(string searchTerm, DateTime? startDate = null);
}