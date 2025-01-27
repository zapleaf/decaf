using MediatR;
using decaf.Application.Channels.Common;

namespace decaf.Application.Channels.Queries.GetByCategory;

public class GetChannelsByCategoryQuery : IRequest<List<ChannelDto>>
{
    public int CategoryId { get; set; }
}
