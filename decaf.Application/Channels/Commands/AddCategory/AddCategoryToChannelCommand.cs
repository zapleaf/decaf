using MediatR;

namespace decaf.Application.Channels.Commands.AddCategory;

public class AddCategoryToChannelCommand : IRequest<bool>
{
    public int CategoryId { get; set; }
    public int ChannelId { get; set; }
}
