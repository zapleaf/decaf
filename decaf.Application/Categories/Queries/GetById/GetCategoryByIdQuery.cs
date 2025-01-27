using MediatR;
using decaf.Domain.Entities;

namespace decaf.Application.Categories.Queries.GetById;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public int Id { get; set; }
}
