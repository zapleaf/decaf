﻿using AutoMapper;
using decaf.Application.AiSummaries.Common;
using decaf.Application.IRepositories;
using MediatR;

namespace decaf.Application.AiSummaries.Queries.GetByVideo;

public class GetAiSummariesByVideoHandler : IRequestHandler<GetAiSummariesByVideoQuery, List<AiSummaryDto>>
{
    private readonly IAiSummaryRepository _aiSummaryRepository;
    private readonly IMapper _mapper;

    public GetAiSummariesByVideoHandler(IAiSummaryRepository aiSummaryRepository, IMapper mapper)
    {
        _aiSummaryRepository = aiSummaryRepository;
        _mapper = mapper;
    }

    public async Task<List<AiSummaryDto>> Handle(GetAiSummariesByVideoQuery request, CancellationToken cancellationToken)
    {
        var summaries = await _aiSummaryRepository.GetByVideoId(request.VideoId);
        return _mapper.Map<List<AiSummaryDto>>(summaries);
    }
}