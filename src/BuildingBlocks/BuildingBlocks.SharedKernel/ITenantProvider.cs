namespace BuildingBlocks.SharedKernel;

public interface ITenantProvider
{
    Guid GetTenantId();
    string GetTenantCode();
}