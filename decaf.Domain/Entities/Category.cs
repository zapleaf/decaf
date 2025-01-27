using decaf.Domain.Common;

namespace decaf.Domain.Entities;

public class Category : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    // Relationships
    public virtual ICollection<Channel> Channels { get; set; } = new List<Channel>();
}
