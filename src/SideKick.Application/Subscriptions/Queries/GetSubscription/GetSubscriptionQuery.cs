using ErrorOr;

using SideKick.Application.Common.Security.Permissions;
using SideKick.Application.Common.Security.Policies;
using SideKick.Application.Common.Security.Request;
using SideKick.Application.Subscriptions.Common;

namespace SideKick.Application.Subscriptions.Queries.GetSubscription;

[Authorize(Permissions = Permission.Subscription.Get, Policies = Policy.SelfOrAdmin)]
public record GetSubscriptionQuery(Guid UserId)
    : IAuthorizeableRequest<ErrorOr<SubscriptionResult>>;