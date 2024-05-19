using SideKick.Domain.Common;

namespace SideKick.Domain.Users.Events;

public record CommitmentRemovedEvent(Guid CommitmentId, Guid UserId) : IDomainEvent;

