using eShop.Catalog.Application.Contracts.Products.Commands.CreateProduct;
using eShop.Catalog.Application.Contracts.Products.Validation;
using eShop.FrameWork.Presentation;
using eShop.FrameWork.Presentation.Extensions;
using eShop.SharedKernel.Application.Abstractions.Mediator;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace eShop.Catalog.Presentation.Products;

public static class CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator(
            IProductNameValidationAdapter nameRules,
            IProductCodeValidationAdapter codeRules
        )

        {
            //RuleFor(m => m.Name)
            //    .NotEmpty()
            //    .WithMessage("نام اجباری است")
            //    .MinimumLength(3)
            //    .WithMessage("حداقل طول سه حرف می باشد");

            RuleFor(m => m.Name).UseDomainRules(nameRules.Validate);
            RuleFor(m => m.Code).UseDomainRules(codeRules.Validate);
            //RuleFor(m => m.Price)
            //    .NotEmpty()
            //    .GreaterThan(0)
            //    .WithMessage("قیمت نمی تواند مقدار منفی باشد");

            RuleFor(m => m.message)
                .MaximumLength(200)
                .WithMessage("توضیحات نباید بیشتر از 200 حرف باشد");

        }
    }
    public class CreateProductEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder builder)
        {
            builder
                .MapPost("/products", CreateProductHandler)
                .Validate<CreateProductCommand>()
                .WithTags(EndpointSchema.ProductTag);
        }
    }
    public static async Task<IResult> CreateProductHandler(
        [FromBody] CreateProductCommand request,
        [FromServices] IDispatcher dispatcher,
        CancellationToken token
    )
    {
        var createProductResult = await dispatcher.Send(request, token);

        //# DRY
        if (createProductResult.IsSuccess)
            return TypedResults.Ok(createProductResult.Value);
        else
            return TypedResults.BadRequest(createProductResult.Error);
    }
}
