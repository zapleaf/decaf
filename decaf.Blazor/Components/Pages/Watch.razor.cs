
using MediatR;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using decaf.Application.Videos.Common;
using decaf.Application.Channels.Common;
using decaf.Infrastructure.Services;
using decaf.Application.Videos.Commands.UpdateNotes;
using decaf.Application.Videos.Queries.GetById;
using decaf.Application.YouTube.Commands.SaveVideos;

namespace decaf.Blazor.Components.Pages;

public partial class Watch
{
    [Inject]
    protected IMediator Mediator { get; set; } = default!;

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = default!;

    [Parameter]
    public int Id { get; set; }

    //private int vidWidth = 935;
    //private int vidHeight = 535;

    //private bool isDisabled = true;
    private string updateMessage;
    private VideoDto video = new();
    private string note = string.Empty;

    //private int videoCount = 0;

    protected override async Task OnInitializedAsync()
    {
        if (Id > 0)
        {
            await GetVideo(Id);
        }
        else
        {
            video = new();
        }
    }

    private async Task UpdateVideos(ChannelDto channel)
    {
        var command = new SaveChannelVideosCommand
        {
            ChannelYTId = channel.YTId,
            ChannelId = channel.Id,
            LastCheckDate = channel.LastCheckDate
        };

        var updatedCount = await Mediator.Send(command);
        updateMessage = $"{updatedCount} added";
        StateHasChanged();
    }

    private async Task GetVideo(int Id)
    {
        var query = new GetVideoByIdQuery { Id = Id };
        video = await Mediator.Send(query);
        StateHasChanged();
    }

    private async Task AddNote()
    {
        try
        {
            var timestamp = await JSRuntime.InvokeAsync<double>("getCurrentTime");
            var stampedNote = $"{TimeSpan.FromSeconds(timestamp):hh\\:mm\\:ss} - {note}";

            var updatedNotes = string.IsNullOrEmpty(video.Notes)
                ? stampedNote
                : $"{video.Notes}\n{stampedNote}";

            var command = new UpdateVideoNotesCommand
            {
                VideoId = video.Id,
                Notes = updatedNotes
            };

            var success = await Mediator.Send(command);

            if (success)
            {
                video.Notes = updatedNotes;
                note = string.Empty;
                updateMessage = "Note saved successfully!";
            }
            else
            {
                updateMessage = "Failed to save note.";
            }
        }
        catch (Exception ex)
        {
            updateMessage = "An error occurred while saving the note.";
            Console.Error.WriteLine($"Error in AddNote: {ex.Message}");
        }
        finally
        {
            StateHasChanged();
        }
    }
}
