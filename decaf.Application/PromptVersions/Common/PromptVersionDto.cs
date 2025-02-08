﻿namespace decaf.Application.PromptVersions.Common;

public class PromptVersionDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}