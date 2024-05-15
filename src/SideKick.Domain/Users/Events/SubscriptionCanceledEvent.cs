using SideKick.Domain.Common;

namespace SideKick.Domain.Users.Events;

public record SubscriptionCanceledEvent(User User, Guid SubscriptionId) : IDomainEvent;