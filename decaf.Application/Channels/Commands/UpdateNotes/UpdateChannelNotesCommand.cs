using MediatR;

namespace decaf.Application.Channels.Commands.UpdateNotes;

public class UpdateChannelNotesCommand : IRequest<bool>
{
    public int ChannelId { get; set; }
    public string Notes { get; set; } = string.Empty;
}