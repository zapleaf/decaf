using AutoMapper;
using decaf.Domain.Entities;

namespace decaf.Application.PromptVersions.Common;

public class PromptVersionMappingProfile : Profile
{
    public PromptVersionMappingProfile()
    {
        CreateMap<PromptVersion, PromptVersionDto>();
        CreateMap<PromptVersionDto, PromptVersion>();
    }
}