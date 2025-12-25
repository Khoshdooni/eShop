using eShop.SharedKernel.Application.Abstractions.Identity;

namespace eShop.FrameWork.Infrastructure.Services;

public class GuidGenerator : IIdGenerator<Guid>
{
    public Guid NewId() => Guid.NewGuid();
}

