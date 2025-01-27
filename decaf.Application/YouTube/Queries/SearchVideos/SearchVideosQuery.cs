using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.YouTube.Queries.SearchVideos;

public class SearchVideosQuery : IRequest<List<Video>>
{
    public required string SearchTerm { get; set; }
    public DateTime? StartDate { get; set; }
}
