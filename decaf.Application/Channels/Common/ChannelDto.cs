﻿using decaf.Application.Categories.Queries.GetAll;
using decaf.Application.Videos.Common;

namespace decaf.Application.Channels.Common;

public class ChannelDto
{
    public int Id { get; set; }
    public string YTId { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ThumbnailURL { get; set; }
    public DateTime PublishedAt { get; set; }
    public DateTime? LastCheckDate { get; set; }
    public ulong? SubscriberCount { get; set; }
    public ulong? VideoCount { get; set; }
    public string? Notes { get; set; }

    public int AvgViews { get; set; }
    public int TrackedVideos { get; set; } = 0;
    public List<CategoryDto> Categories { get; set; } = new();
    public List<VideoDto> Videos { get; set; } = new();
}
