using ErrorOr;

using SideKick.Application.Common.Security.Permissions;
using SideKick.Application.Common.Security.Policies;
using SideKick.Application.Common.Security.Request;
using SideKick.Application.Subscriptions.Common;
using SideKick.Domain.Users;

namespace SideKick.Application.Subscriptions.Commands.CreateSubscription;

[Authorize(Permissions = Permission.Subscription.Create, Policies = Policy.SelfOrAdmin)]
public record CreateSubscriptionCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType)
    : IAuthorizeableRequest<ErrorOr<SubscriptionResult>>;