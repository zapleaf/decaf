using decaf.Application.IRepositories;
using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.Videos.Commands.Create;

public class CreateVideoHandler : IRequestHandler<CreateVideoCommand, int>
{
    private readonly IVideoRepository _videoRepository;

    public CreateVideoHandler(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<int> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
    {
        var video = new Video
        {
            YTId = request.YTId,
            YTChannelId = request.YTChannelId,
            Title = request.Title,
            ThumbnailUrl = request.ThumbnailUrl,
            Description = request.Description,
            PublishedAt = request.PublishedAt,
            Duration = request.Duration,
            Notes = request.Notes,
            ChannelId = request.ChannelId,
            ViewCount = request.ViewCount,
            LikeCount = request.LikeCount,
            CommentCount = request.CommentCount,
            RatioAvgViews = request.RatioAvgViews
        };

        var result = await _videoRepository.Create(video);
        return result.Id;
    }
}