using MediatR;

namespace decaf.Application.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
}