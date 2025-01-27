using decaf.Application.IRepositories;
using decaf.Application.IServices;
using decaf.Application.YouTube.Commands.SaveVideos;
using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.YouTube.Commands.SaveChannel;

public class SaveChannelHandler : IRequestHandler<SaveChannelCommand, int>
{
    private readonly IChannelRepository _channelRepository;
    private readonly IYouTubeApiService _youTubeService;

    public SaveChannelHandler(IChannelRepository channelRepository, IYouTubeApiService youTubeService)
    {
        _channelRepository = channelRepository;
        _youTubeService = youTubeService;
    }

    public async Task<int> Handle(SaveChannelCommand request, CancellationToken cancellationToken)
    {
        // Get additional stats from YouTube
        var channelStats = await _youTubeService.GetChannelStats(request.YTId);

        var channel = new Channel
        {
            YTId = request.YTId,
            Title = request.Title,
            Description = request.Description,
            ThumbnailURL = request.ThumbnailURL,
            PublishedAt = request.PublishedAt,
            SubscriberCount = channelStats.SubscriberCount,
            VideoCount = channelStats.VideoCount
        };

        var result = await _channelRepository.Create(channel);
        return result.Id;
    }
}
