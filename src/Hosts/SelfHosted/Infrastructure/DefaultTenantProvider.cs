using BuildingBlocks.SharedKernel;

namespace SelfHosted.Infrastructure;

public class DefaultTenantProvider : ITenantProvider
{
    private static readonly Guid SelfHostedTenantId = Guid.Parse("00000000-0000-0000-0000-000000000001");

    public Guid GetTenantId() => SelfHostedTenantId;

    public string GetTenantCode() => "self-hosted-user";
}