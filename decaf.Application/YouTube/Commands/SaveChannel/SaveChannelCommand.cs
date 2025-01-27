using MediatR;

namespace decaf.Application.YouTube.Commands.SaveVideos;

public class SaveChannelCommand : IRequest<int>
{
    public required string YTId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ThumbnailURL { get; set; }
    public DateTime PublishedAt { get; set; }
}
