using decaf.Application.Videos.Common;
using MediatR;

namespace decaf.Application.Videos.Queries.GetByCategory;

public class GetVideosByCategoryQuery : IRequest<List<VideoDto>>
{
    public int CategoryId { get; set; }
}
