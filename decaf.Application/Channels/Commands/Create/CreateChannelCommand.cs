﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decaf.Application.Channels.Commands.Create;

public class CreateChannelCommand : IRequest<int>
{
    public string YTId { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? UploadsPlaylistId { get; set; }
    public string? ThumbnailURL { get; set; }
    public string? Notes { get; set; }
    public ulong? VideoCount { get; set; }
    public ulong? SubscriberCount { get; set; }
    public DateTime PublishedAt { get; set; }
}