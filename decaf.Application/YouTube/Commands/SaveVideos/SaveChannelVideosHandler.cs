using decaf.Application.IRepositories;
using decaf.Application.IServices;
using decaf.Domain.Entities;
using decaf.Domain.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace decaf.Application.YouTube.Commands.SaveVideos;

public class SaveChannelVideosHandler : IRequestHandler<SaveChannelVideosCommand, int>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IYouTubeApiService _youTubeService;
    private readonly IChannelRepository _channelRepository;

    public SaveChannelVideosHandler(IVideoRepository videoRepository, IYouTubeApiService youTubeService, IChannelRepository channelRepository)
    {
        _videoRepository = videoRepository;
        _youTubeService = youTubeService;
        _channelRepository = channelRepository;
    }

    public async Task<int> Handle(SaveChannelVideosCommand request, CancellationToken cancellationToken)
    {
        // Get the current channel
        var currentChannel = await _channelRepository.Get(request.ChannelYTId);

        // If the LastCheckDate is null or minDate we assume its a new channel and we go back 1 year.
        if (request.LastCheckDate.IsValidDate()) { request.LastCheckDate = DateTime.UtcNow.AddYears(-1); }

        // Get videos from YouTube
        var videos = await _youTubeService.GetChannelVideos(request.ChannelYTId, request.LastCheckDate);

        // Process each video
        var validVideos = new List<Video>();
        foreach (var video in videos.Where(v => !v.Title.ToLower().Contains("#shorts")))
        {
            if (await _videoRepository.Get(video.YTId) != null) continue;
            if (validVideos.Any(v => v.YTId == video.YTId)) continue;

            video.Duration = await _youTubeService.GetDuration(video.YTId);

            // Only process videos within our target duration range
            if (video.Duration >= 65 && video.Duration <= 5400)
            {
                video.ChannelId = request.ChannelId;
                await _youTubeService.GetStats(video);
                validVideos.Add(video);
            }
        }

        var addCount = await _videoRepository.Create(validVideos);

        currentChannel.LastCheckDate = DateTime.Now;
        await _channelRepository.Update(currentChannel);

        // Save valid videos to database
        return addCount;
    }
}
