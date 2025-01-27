using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.YouTube.Queries.GetChannelStats;

public class GetChannelStatsQuery : IRequest<Channel>
{
    public required string YoutubeId { get; set; }
}
