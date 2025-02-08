﻿using decaf.Application.AiAnalysises.Common;
using MediatR;

namespace decaf.Application.AiAnalysises.Commands.Create;

public class CreateAiAnalysisCommand : IRequest<AiAnalysisDto>
{
    public int ChannelId { get; set; }
    public string AnalysisType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public string Analysis { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int? TokensUsed { get; set; }
}