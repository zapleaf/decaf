using MediatR;
using decaf.Application.Videos.Common;

namespace decaf.Application.Videos.Queries.GetById;

public class GetVideoByIdQuery : IRequest<VideoDto>
{
    public int Id { get; set; }
}
