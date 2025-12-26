using eShop.SharedKernel.Application.Abstractions.Mediator;

namespace eShop.Catalog.Application.Contracts.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, string Code, decimal? Price, string CurrencyCode, string? message) : ICommand<CreateProductResponse>
{
}
