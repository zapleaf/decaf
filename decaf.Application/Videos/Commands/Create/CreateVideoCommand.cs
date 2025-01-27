﻿using MediatR;

namespace decaf.Application.Videos.Commands.Create;

public class CreateVideoCommand : IRequest<int>
{
    public string YTId { get; set; } = string.Empty;
    public string? YTChannelId { get; set; }
    public string? Title { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? Description { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int? Duration { get; set; }
    public string? Notes { get; set; }
    public int? ChannelId { get; set; }
    public int ViewCount { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public decimal RatioAvgViews { get; set; }
}
