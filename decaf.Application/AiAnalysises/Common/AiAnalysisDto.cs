﻿namespace decaf.Application.AiAnalysises.Common;

public class AiAnalysisDto
{
    public int Id { get; set; }
    public int ChannelId { get; set; }
    public string AnalysisType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public string Analysis { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int? TokensUsed { get; set; }
    public DateTime CreatedAt { get; set; }
}