using ErrorOr;
using SideKick.Domain.Commitments;
using SideKick.Domain.Common;
using SideKick.Domain.GroupChats;
using SideKick.Domain.Reminders;
using SideKick.Domain.Subscriptions;
using SideKick.Domain.Users.Events;
using Throw;

namespace SideKick.Domain.Users
{
    public class User : Entity
    {
        private readonly Calendar _calendar = null!;
        private readonly List<Guid> _reminderIds = new();
        private readonly List<Guid> _dismissedReminderIds = new();
        private readonly List<Guid> _commitmentIds = new();  // Changed from List<Commitment>
        private readonly List<Guid> _groupChatIds = new();   // Changed from List<GroupChat>

        public Subscription Subscription { get; private set; } = null!;
        public string Email { get; } = null!;
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;

        public User(
            Guid id,
            string firstName,
            string lastName,
            string email,
            Subscription subscription,
            Calendar? calendar = null)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Subscription = subscription;
            _calendar = calendar ?? Calendar.Empty();
        }

        public ErrorOr<Success> SetReminder(Reminder reminder)
        {
            if (Subscription == Subscription.Canceled)
            {
                return Error.NotFound(description: "Subscription not found");
            }

            reminder.SubscriptionId.Throw().IfNotEquals(Subscription.Id);

            if (HasReachedDailyReminderLimit(reminder.DateTime))
            {
                return UserErrors.CannotCreateMoreRemindersThanSubscriptionAllows;
            }

            _calendar.IncrementEventCount(reminder.Date);
            _reminderIds.Add(reminder.Id);
            _domainEvents.Add(new ReminderSetEvent(reminder));

            return Result.Success;
        }

        public ErrorOr<Success> DismissReminder(Guid reminderId)
        {
            if (Subscription == Subscription.Canceled)
            {
                return Error.NotFound(description: "Subscription not found");
            }

            if (!_reminderIds.Contains(reminderId))
            {
                return Error.NotFound(description: "Reminder not found");
            }

            if (_dismissedReminderIds.Contains(reminderId))
            {
                return Error.Conflict(description: "Reminder already dismissed");
            }

            _dismissedReminderIds.Add(reminderId);
            _domainEvents.Add(new ReminderDismissedEvent(reminderId));

            return Result.Success;
        }

        public ErrorOr<Success> CancelSubscription(Guid subscriptionId)
        {
            if (subscriptionId != Subscription.Id)
            {
                return Error.NotFound(description: "Subscription not found");
            }

            Subscription = Subscription.Canceled;
            _domainEvents.Add(new SubscriptionCanceledEvent(this, subscriptionId));

            return Result.Success;
        }

        public ErrorOr<Success> DeleteReminder(Reminder reminder)
        {
            if (Subscription == Subscription.Canceled)
            {
                return Error.NotFound(description: "Subscription not found");
            }

            if (!_reminderIds.Remove(reminder.Id))
            {
                return Error.NotFound(description: "Reminder not found");
            }

            _dismissedReminderIds.Remove(reminder.Id);
            _calendar.DecrementEventCount(reminder.Date);
            _domainEvents.Add(new ReminderDeletedEvent(reminder.Id));

            return Result.Success;
        }

        public void DeleteAllReminders()
        {
            _reminderIds.ForEach(reminderId =>
                _domainEvents.Add(new ReminderDeletedEvent(reminderId)));
            _reminderIds.Clear();
        }

        public ErrorOr<Success> AddCommitment(Commitment commitment)
        {
            _commitmentIds.Add(commitment.Id);
            _domainEvents.Add(new CommitmentAddedEvent(commitment));
            return Result.Success;
        }

        public ErrorOr<Success> RemoveCommitment(Guid commitmentId)
        {
            if (_commitmentIds.Remove(commitmentId))
            {
                _domainEvents.Add(new CommitmentRemovedEvent(commitmentId, this.Id));
                return Result.Success;
            }

            return Error.NotFound("Commitment not found");
        }

        public ErrorOr<Success> AddGroupChat(GroupChat groupChat)
        {
            _groupChatIds.Add(groupChat.Id);
            _domainEvents.Add(new GroupChatAddedEvent(groupChat));
            return Result.Success;
        }

        public ErrorOr<Success> RemoveGroupChat(Guid groupChatId)
        {
            if (_groupChatIds.Remove(groupChatId))
            {
                _domainEvents.Add(new GroupChatRemovedEvent(groupChatId, this.Id));
                return Result.Success;
            }

            return Error.NotFound("Group chat not found");
        }

        public List<Guid> GetCommitmentIds()
        {
            return new List<Guid>(_commitmentIds);
        }

        public List<Guid> GetGroupChatIds()
        {
            return new List<Guid>(_groupChatIds);
        }

        private bool HasReachedDailyReminderLimit(DateTimeOffset dateTime)
        {
            var dailyReminderCount = _calendar.GetNumEventsOnDay(dateTime.Date);

            return dailyReminderCount >= Subscription.SubscriptionType.GetMaxDailyReminders()
                || dailyReminderCount == int.MaxValue;
        }

        private User() { }
    }
}
