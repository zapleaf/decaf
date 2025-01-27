﻿using AutoMapper;
using decaf.Domain.Entities;

namespace decaf.Application.Channels.Common;

public class ChannelMappingProfile : Profile
{
    public ChannelMappingProfile()
    {
        CreateMap<Channel, ChannelDto>()
            .ForMember(dest => dest.Videos,
                opt => opt.MapFrom(src => src.Videos.Where(v => !v.IsDeleted)))
            .ForMember(dest => dest.TrackedVideos,
                opt => opt.MapFrom(src => src.Videos.Count(v => !v.IsDeleted)));

        CreateMap<ChannelDto, Channel>();
    }
}
