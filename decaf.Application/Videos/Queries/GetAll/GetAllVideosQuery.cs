using decaf.Application.Videos.Common;
using MediatR;

namespace decaf.Application.Videos.Queries.GetAll;

public class GetAllVideosQuery : IRequest<List<VideoDto>>
{
}
