using MediatR;

namespace decaf.Application.Videos.Commands.UpdateVideo;

public class UpdateVideoNotesCommand : IRequest<bool>
{
    public int VideoId { get; set; }
    public string Notes { get; set; } = string.Empty;
}