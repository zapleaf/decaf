using decaf.Domain.Common;
using decaf.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class AiAnalysis : Entity
{
    [Required]
    public int ChannelId { get; set; }
    public virtual Channel Channel { get; set; } = null!;

    [Required]
    public int PromptVersionId { get; set; }
    public virtual PromptVersion PromptVersion { get; set; } = null!;

    [Required]
    public string AnalysisType { get; set; } = string.Empty;

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Analysis { get; set; } = string.Empty;

    [Required]
    public string Provider { get; set; } = string.Empty;

    [Required]
    public string Model { get; set; } = string.Empty;

    public int? TokensUsed { get; set; }
}