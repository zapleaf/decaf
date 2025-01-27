using decaf.Application.Categories.Queries.GetAll;
using MediatR;

namespace decaf.Application.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public CreateCategoryRequest Category { get; set; } = null!;
}