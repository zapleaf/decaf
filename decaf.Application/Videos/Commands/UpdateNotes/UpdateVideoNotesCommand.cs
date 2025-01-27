using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decaf.Application.Videos.Commands.UpdateNotes;

public class UpdateVideoNotesCommand : IRequest<bool>
{
    public int VideoId { get; set; }
    public string Notes { get; set; } = string.Empty;
}
