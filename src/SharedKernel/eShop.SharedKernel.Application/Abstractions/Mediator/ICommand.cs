using eShop.SharedKernel.Domain.Results;

namespace eShop.SharedKernel.Application.Abstractions.Mediator;

public interface ICommand : IRequest<Result> { }
public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }

