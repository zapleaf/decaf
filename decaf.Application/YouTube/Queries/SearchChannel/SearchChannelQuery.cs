using MediatR;
using decaf.Application.Channels.Common;

namespace decaf.Application.YouTube.Queries.SearchChannel;

public class SearchChannelQuery : IRequest<List<ChannelDto>>
{
    public required string SearchTerm { get; set; }
}
