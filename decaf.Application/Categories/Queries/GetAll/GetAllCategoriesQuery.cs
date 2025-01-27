using MediatR;

namespace decaf.Application.Categories.Queries.GetAll;

public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}