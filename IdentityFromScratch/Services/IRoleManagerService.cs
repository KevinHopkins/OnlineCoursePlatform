namespace IdentityFromScratch.Services;

public interface IRoleManagerService
{
    public Task EnsureRoleExistsAsync(string roleName);
}