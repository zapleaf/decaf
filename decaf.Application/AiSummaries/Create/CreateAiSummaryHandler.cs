using AutoMapper;
using decaf.Application.IRepositories;
using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.AiSummaries.Commands.Create;

public class CreateAiSummaryHandler : IRequestHandler<CreateAiSummaryCommand, int>
{
    private readonly IAiSummaryRepository _aiSummaryRepository;
    private readonly IMapper _mapper;

    public CreateAiSummaryHandler(IAiSummaryRepository aiSummaryRepository, IMapper mapper)
    {
        _aiSummaryRepository = aiSummaryRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateAiSummaryCommand request, CancellationToken cancellationToken)
    {
        var aiSummary = _mapper.Map<AiSummary>(request);
        var result = await _aiSummaryRepository.Create(aiSummary);
        return result.Id;
    }
}