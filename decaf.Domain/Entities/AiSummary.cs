﻿using decaf.Domain.Common;
using decaf.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class AiSummary : Entity
{
    [Required]
    public int VideoId { get; set; }
    public virtual Video Video { get; set; } = null!;

    [Required]
    public int PromptVersionId { get; set; }
    public virtual PromptVersion PromptVersion { get; set; } = null!;

    [Required]
    public string Summary { get; set; } = string.Empty;

    [Required]
    public string Transcript { get; set; } = string.Empty;

    [Required]
    public string Provider { get; set; } = string.Empty;

    [Required]
    public string Model { get; set; } = string.Empty;

    public int? TokensUsed { get; set; }
}