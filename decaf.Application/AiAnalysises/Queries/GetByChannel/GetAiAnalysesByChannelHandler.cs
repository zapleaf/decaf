using AutoMapper;
using decaf.Application.AiAnalysises.Common;
using decaf.Application.IRepositories;
using MediatR;

namespace decaf.Application.AiAnalysises.Queries.GetByChannel;

public class GetAiAnalysesByChannelHandler : IRequestHandler<GetAiAnalysesByChannelQuery, List<AiAnalysisDto>>
{
    private readonly IAiAnalysisRepository _aiAnalysisRepository;
    private readonly IMapper _mapper;

    public GetAiAnalysesByChannelHandler(IAiAnalysisRepository aiAnalysisRepository, IMapper mapper)
    {
        _aiAnalysisRepository = aiAnalysisRepository;
        _mapper = mapper;
    }

    public async Task<List<AiAnalysisDto>> Handle(GetAiAnalysesByChannelQuery request, CancellationToken cancellationToken)
    {
        var analyses = await _aiAnalysisRepository.GetByChannelId(request.ChannelId);
        return _mapper.Map<List<AiAnalysisDto>>(analyses);
    }
}