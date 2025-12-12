using eShop.SharedKernel.Domain.Abstractions;
using eShop.SharedKernel.Domain.Results;

namespace eShop.SharedKernel.Domain.Rules;

public sealed class InvariantBuilder<T>
    where T : IEntity
{
    private readonly T _entity;

    private readonly List<ICheckRule<T>> _rules = new();

    private readonly List<Result> _nestedResults = new();

    public InvariantBuilder(T entity) => _entity = entity;
    public InvariantBuilder<T> Include(ICheckRule<T> rule)
    {
        _rules.Add(rule);
        return this;
    }

    public InvariantBuilder<T> IncludeNested(params IHasInvariant[] nested)
    {
        nested
              .ToList()
              .ForEach(item =>
              {
                  var result = item.EnsureInvariants();
                  if (result.IsFailure)
                  {
                      _nestedResults.Add(result);
                  }
              });
        return this;
    }



    public Result EnsureValid()
    {
        var brokenRule = _rules.FirstOrDefault(r => r.IsBroken(_entity));
        if (brokenRule != null)
        {
            return Result.Failure(brokenRule.Error);
        }

        var hasFailedNested = _nestedResults.Any(c => c.IsFailure);
        if (hasFailedNested)
        {
            return _nestedResults.First(r => r.IsFailure);
        }

        return Result.Success();
    }
    //public Result<T> EnsureValid()
    //{
    //    var brokenRule = _rules.FirstOrDefault(r => r.IsBroken(_entity));
    //    if (brokenRule != null)
    //    {
    //        return Result.Failure<T>(brokenRule.Error);
    //    }

    //    return Result.Success(_entity);
    //}
}
