using MediatR;

namespace decaf.Application.YouTube.Commands.SaveVideos;

public class SaveChannelVideosCommand : IRequest<int>
{
    public required string ChannelYTId { get; set; }
    public int ChannelId { get; set; }
    public DateTime? LastCheckDate { get; set; }
}