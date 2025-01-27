using decaf.Application.IRepositories;
using decaf.Domain.Entities;
using MediatR;

namespace decaf.Application.Categories.Queries.GetById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetByIdWithChildren(request.Id);
    }
}
