using eShop.Catalog.Application.Contracts.Products.Commands.CreateProduct;
using eShop.SharedKernel.Application.Abstractions.Identity;
using eShop.SharedKernel.Application.Abstractions.Mediator;
using eShop.SharedKernel.Domain.Results;

namespace eShop.Catalog.Application.Products;

internal class CreateProductHandler(IIdGenerator<Guid> idGenerator) : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public Task<Result<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken token)
    {
        var productId = idGenerator.NewId();
        return Task.FromResult(Result.Success(new CreateProductResponse(productId)));
    }
}
