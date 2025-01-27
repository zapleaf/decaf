using AutoMapper;
using decaf.Application.Categories.Commands.Create;
using decaf.Application.Categories.Queries.GetAll;
using decaf.Application.Categories.Queries.GetById;
using decaf.Domain.Entities;

namespace decaf.Application.Categories.Common;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ChannelCount,
                      opt => opt.MapFrom(src => src.Channels.Count));

        CreateMap<CreateCategoryRequest, Category>();

        CreateMap<Category, CategoryDetailsDto>();

        CreateMap<Channel, CategoryChannelDto>();
    }
}
