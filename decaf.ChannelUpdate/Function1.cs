using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using decaf.Infrastructure.Data;
using decaf.Application.YouTube.Commands.SaveVideos;

namespace decaf.ChannelUpdate;

public class UpdateYouTubeChannels
{
    private readonly ILogger<UpdateYouTubeChannels> _logger;
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public UpdateYouTubeChannels(
        ILogger<UpdateYouTubeChannels> logger,
        AppDbContext context,
        IMediator mediator)
    {
        _logger = logger;
        _context = context;
        _mediator = mediator;
    }

    [Function("UpdateYouTubeChannels")]
    public async Task Run([TimerTrigger("0 0 * * * *")] // Runs at the start of every hour
        TimerInfo timerInfo)
    {
        try
        {
            _logger.LogInformation($"YouTube channel update function started at: {DateTime.Now}");

            // First try to find a channel that has never been checked (LastCheckDate is null)
            var channel = await _context.Channels
                .Where(c => !c.IsDeleted && c.LastCheckDate.HasValue)
                .FirstOrDefaultAsync();

            // If no unchecked channels found, get the oldest checked channel that's at least 3 days old
            if (channel == null)
            {
                var threeDaysAgo = DateTime.UtcNow.AddDays(-3);
                channel = await _context.Channels
                    .Where(c => !c.IsDeleted)
                    .Where(c => c.LastCheckDate <= threeDaysAgo)
                    .OrderBy(c => c.LastCheckDate)
                    .FirstOrDefaultAsync();
            }

            if (channel == null)
            {
                _logger.LogInformation("No channels need updating at this time.");
                return;
            }

            _logger.LogInformation($"Updating channel: {channel.Title} (ID: {channel.Id})");

            var command = new SaveChannelVideosCommand
            {
                ChannelYTId = channel.YTId,
                ChannelId = channel.Id,
                LastCheckDate = channel.LastCheckDate
            };

            var updatedCount = await _mediator.Send(command);
            _logger.LogInformation($"Added {updatedCount} new videos for channel {channel.Title}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating YouTube channels");
            throw;
        }
    }
}
