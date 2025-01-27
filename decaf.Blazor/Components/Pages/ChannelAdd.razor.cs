using decaf.Application.Channels.Common;
using decaf.Application.YouTube.Commands.SaveVideos;
using decaf.Application.YouTube.Queries.SearchChannel;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace decaf.Blazor.Components.Pages;

public partial class ChannelAdd
{
    [Inject]
    private IMediator Mediator { get; set; } = default!;

    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    protected string searchTerm = "";
    protected bool IsBusy = false;
    protected List<ChannelDto> Channels = new();

    protected async Task SearchChannels()
    {
        try
        {
            var query = new SearchChannelQuery { SearchTerm = searchTerm };
            Channels = await Mediator.Send(query);
            StateHasChanged();
        }
        catch (Exception ex)
        {
            // TODO: Add error handling/messaging
            Console.WriteLine($"Error searching channels: {ex.Message}");
        }
    }

    protected async Task SaveChannel(string ytId)
    {
        if (string.IsNullOrEmpty(ytId))
            return;

        IsBusy = true;
        try
        {
            var channelToSave = Channels.FirstOrDefault(c => c.YTId == ytId);
            if (channelToSave != null)
            {
                // Create and send the SaveChannelCommand
                var saveCommand = new SaveChannelCommand
                {
                    YTId = channelToSave.YTId,
                    Title = channelToSave.Title,
                    Description = channelToSave.Description,
                    ThumbnailURL = channelToSave.ThumbnailURL,
                    PublishedAt = channelToSave.PublishedAt
                };

                var newChannelId = await Mediator.Send(saveCommand);

                if (newChannelId > 0)
                {
                    // Save channel videos
                    var saveVideosCommand = new SaveChannelVideosCommand
                    {
                        ChannelYTId = ytId,
                        ChannelId = newChannelId,
                        LastCheckDate = null // This is a new channel, so get all videos
                    };

                    await Mediator.Send(saveVideosCommand);
                    NavigationManager.NavigateTo($"/channels/{newChannelId}/details");
                }
            }
        }
        catch (Exception ex)
        {
            // TODO: Add error handling/messaging
            Console.WriteLine($"Error saving channel: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }
}