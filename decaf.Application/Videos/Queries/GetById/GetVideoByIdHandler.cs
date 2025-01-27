using AutoMapper;
using decaf.Application.IRepositories;
using decaf.Application.Videos.Common;
using MediatR;

namespace decaf.Application.Videos.Queries.GetById;

public class GetVideoByIdHandler : IRequestHandler<GetVideoByIdQuery, VideoDto>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;

    public GetVideoByIdHandler(IVideoRepository videoRepository, IMapper mapper)
    {
        _videoRepository = videoRepository;
        _mapper = mapper;
    }

    public async Task<VideoDto> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(request.Id);
        return _mapper.Map<VideoDto>(video);
    }
}