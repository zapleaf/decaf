using MediatR;

namespace decaf.Application.Channels.Commands.RemoveCategory;

public class RemoveCategoryFromChannelCommand : IRequest<bool>
{
    public int CategoryId { get; set; }
    public int ChannelId { get; set; }
}