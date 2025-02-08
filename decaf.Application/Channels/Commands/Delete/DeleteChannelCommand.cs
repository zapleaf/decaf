using MediatR;

namespace decaf.Application.Channels.Commands.Delete;

public class DeleteChannelCommand : IRequest<bool>
{
    public int ChannelId { get; set; }
}
