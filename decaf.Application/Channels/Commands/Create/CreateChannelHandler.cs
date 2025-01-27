using decaf.Application.IRepositories;
using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.Channels.Commands.Create;

public class CreateChannelHandler : IRequestHandler<CreateChannelCommand, int>
{
    private readonly IChannelRepository _channelRepository;

    public CreateChannelHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<int> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
    {
        var channel = new Channel
        {
            YTId = request.YTId,
            Title = request.Title,
            Description = request.Description,
            UploadsPlaylistId = request.UploadsPlaylistId,
            ThumbnailURL = request.ThumbnailURL,
            Notes = request.Notes,
            VideoCount = request.VideoCount,
            SubscriberCount = request.SubscriberCount,
            PublishedAt = request.PublishedAt
        };

        var result = await _channelRepository.Create(channel);
        return result?.Id ?? 0;
    }
}
