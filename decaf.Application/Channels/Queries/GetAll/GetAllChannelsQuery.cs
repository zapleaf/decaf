using MediatR;
using decaf.Application.Channels.Common;

namespace decaf.Application.Channels.Queries.GetAll;

public class GetAllChannelsQuery : IRequest<List<ChannelDto>>
{
    public bool IncludeCategories { get; set; }
    public bool IncludeVideos { get; set; }
}