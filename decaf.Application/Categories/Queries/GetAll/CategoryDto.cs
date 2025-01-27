﻿namespace decaf.Application.Categories.Queries.GetAll;

public class CategoryDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public int ChannelCount { get; set; }
}