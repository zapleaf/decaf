using AutoMapper;
using decaf.Domain.Entities;
using decaf.Application.AiAnalysises.Commands.Create;

namespace decaf.Application.AiAnalysises.Common;

public class AiAnalysisMappingProfile : Profile
{
    public AiAnalysisMappingProfile()
    {
        CreateMap<AiAnalysis, AiAnalysisDto>();
        CreateMap<CreateAiAnalysisCommand, AiAnalysis>();
    }
}