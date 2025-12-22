using eShop.Catalog.Domain.Products.Entities;
using eShop.Catalog.Domain.Products.Enums;
using eShop.SharedKernel.Domain.Errors;
using eShop.SharedKernel.Domain.Rules;

namespace eShop.Catalog.Domain.Products.Rules.Transitions;

internal class CanActiveProductRule : ITransitionRule<Product>
{
    public Error Error => throw new NotImplementedException();

    //1
    //public bool CanTransition(Product product) => product.Status.CanBeActivated; 

    //2
    public bool CanTransition(Product product) => ProductStateTransitionMap.CanTransition(product.Status, ProductStatus.Active);

}
