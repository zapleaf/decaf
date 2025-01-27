using AutoMapper;
using decaf.Application.IRepositories;
using decaf.Application.Videos.Common;
using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.Videos.Queries.GetAll;

public class GetAllVideosHandler : IRequestHandler<GetAllVideosQuery, List<VideoDto>>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;

    public GetAllVideosHandler(IVideoRepository videoRepository, IMapper mapper)
    {
        _videoRepository = videoRepository;
        _mapper = mapper;
    }

    public async Task<List<VideoDto>> Handle(GetAllVideosQuery request, CancellationToken cancellationToken)
    {
        var videos = await _videoRepository.GetAll();
        return _mapper.Map<List<VideoDto>>(videos);
    }
}
