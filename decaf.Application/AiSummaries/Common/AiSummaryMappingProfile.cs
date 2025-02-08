using AutoMapper;
using decaf.Domain.Entities;
using decaf.Application.AiSummaries.Commands.Create;

namespace decaf.Application.AiSummaries.Common;

public class AiSummaryMappingProfile : Profile
{
    public AiSummaryMappingProfile()
    {
        CreateMap<AiSummary, AiSummaryDto>();
        CreateMap<CreateAiSummaryCommand, AiSummary>();
    }
}
