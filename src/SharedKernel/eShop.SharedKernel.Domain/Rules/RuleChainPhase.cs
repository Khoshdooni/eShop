namespace eShop.SharedKernel.Domain.Rules;

public enum RuleChainPhase
{
    None,
    TransitionChecked,
    BusinessChecked,
    Validate,
    Completed
}
