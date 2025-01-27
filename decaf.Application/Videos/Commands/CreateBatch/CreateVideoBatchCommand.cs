using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.Videos.Commands.CreateBatch;

public class CreateVideoBatchCommand : IRequest<int>
{
    public List<Video> Videos { get; set; } = new List<Video>();
}
