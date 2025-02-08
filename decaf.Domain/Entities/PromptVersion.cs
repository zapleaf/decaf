using decaf.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace decaf.Domain.Entities;

public class PromptVersion : Entity
{
    [Required]
    public string Code { get; set; } = string.Empty;

    [Required]
    public string Version { get; set; } = string.Empty;

    [Required]
    public string Prompt { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Navigation properties
    public virtual ICollection<AiSummary> AiSummaries { get; set; } = [];
    public virtual ICollection<AiAnalysis> AiAnalyses { get; set; } = [];
}