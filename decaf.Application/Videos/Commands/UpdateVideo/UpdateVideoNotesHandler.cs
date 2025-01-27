using decaf.Application.IRepositories;
using MediatR;

namespace decaf.Application.Videos.Commands.UpdateVideo;

public class UpdateVideoNotesHandler : IRequestHandler<UpdateVideoNotesCommand, bool>
{
    private readonly IVideoRepository _videoRepository;

    public UpdateVideoNotesHandler(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<bool> Handle(UpdateVideoNotesCommand request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(request.VideoId);
        if (video == null)
            return false;

        video.Notes = request.Notes;
        await _videoRepository.Update(video);
        return true;
    }
}
