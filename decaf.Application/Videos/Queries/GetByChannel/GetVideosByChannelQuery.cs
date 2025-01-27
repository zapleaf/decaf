using MediatR;
using decaf.Application.Videos.Common;

namespace decaf.Application.Videos.Queries.GetByChannel;

public class GetVideosByChannelQuery : IRequest<List<VideoDto>>
{
    public int ChannelId { get; set; }
}
