﻿using decaf.Application.Categories.Common;

namespace decaf.Application.Categories.Queries.GetById;

public class CategoryDetailsDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
    public List<CategoryChannelDto> Channels { get; set; } = new();
}