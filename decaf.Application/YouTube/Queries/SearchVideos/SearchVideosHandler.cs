using decaf.Application.IServices;
using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.YouTube.Queries.SearchVideos;

public class SearchVideosHandler : IRequestHandler<SearchVideosQuery, List<Video>>
{
    private readonly IYouTubeApiService _youTubeService;

    public SearchVideosHandler(IYouTubeApiService youTubeService)
    {
        _youTubeService = youTubeService;
    }

    public async Task<List<Video>> Handle(SearchVideosQuery request, CancellationToken cancellationToken)
    {
        return await _youTubeService.VideoSearch(request.SearchTerm, request.StartDate);
    }
}