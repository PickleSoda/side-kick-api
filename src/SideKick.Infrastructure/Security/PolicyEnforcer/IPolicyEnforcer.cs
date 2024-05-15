using SideKick.Application.Common.Security.Request;
using SideKick.Infrastructure.Security.CurrentUserProvider;

using ErrorOr;

namespace SideKick.Infrastructure.Security.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeableRequest<T> request,
        CurrentUser currentUser,
        string policy);
}