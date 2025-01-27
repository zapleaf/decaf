using MediatR;

namespace decaf.Application.Channels.Commands.UpdateStats;

public class UpdateChannelStatsCommand : IRequest<bool>
{
    public int ChannelId { get; set; }
}
