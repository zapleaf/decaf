using AutoMapper;
using decaf.Application.AiSummaries.Common;
using decaf.Application.IRepositories;
using MediatR;

namespace decaf.Application.AiSummaries.Queries.GetMostRecent;

public class GetMostRecentAiSummaryHandler : IRequestHandler<GetMostRecentAiSummaryQuery, AiSummaryDto?>
{
    private readonly IAiSummaryRepository _aiSummaryRepository;
    private readonly IMapper _mapper;

    public GetMostRecentAiSummaryHandler(IAiSummaryRepository aiSummaryRepository, IMapper mapper)
    {
        _aiSummaryRepository = aiSummaryRepository;
        _mapper = mapper;
    }

    public async Task<AiSummaryDto?> Handle(GetMostRecentAiSummaryQuery request, CancellationToken cancellationToken)
    {
        var summary = await _aiSummaryRepository.GetMostRecentByVideoId(request.VideoId);
        return _mapper.Map<AiSummaryDto?>(summary);
    }
}