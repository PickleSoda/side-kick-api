using SideKick.Domain.Commitments;
using SideKick.Domain.Common;

namespace SideKick.Domain.Users.Events;
public record CommitmentAddedEvent(Commitment Commitments) : IDomainEvent;
