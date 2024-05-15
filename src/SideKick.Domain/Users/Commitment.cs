using SideKick.Domain.Common;
using SideKick.Domain.Habits;
using SideKick.Domain.Reminders;

namespace SideKick.Domain.Commitments
{
    public class Commitment : Entity
    {
        public Habit TargetHabit { get; private set; }
        public CommitmentStatus Status { get; private set; }
        public int LengthInDays { get; private set; }
        public Guid CreatorId { get; private set; }
        public List<Reminder> Reminders { get; private set; }

        public Commitment(
            Guid id,
            Habit targetHabit,
            CommitmentStatus status,
            int lengthInDays,
            Guid creatorId,
            List<Reminder> reminders)
            : base(id)
        {
            TargetHabit = targetHabit;
            Status = status;
            LengthInDays = lengthInDays;
            CreatorId = creatorId;
            Reminders = reminders;
        }

        public void AddReminder(Reminder reminder)
        {
            Reminders.Add(reminder);
        }

        public void ChangeStatus(CommitmentStatus status)
        {
            Status = status;
        }

        public static Commitment CreateFromHabit(Guid creatorId, Habit habit, int lengthInDays)
        {
            var commitmentId = Guid.NewGuid();
            var reminders = habit.Reminders.ConvertAll(reminder =>
                new Reminder(creatorId, reminder.SubscriptionId, reminder.Text, DateTime.Now.AddDays(reminder.DateTime.Day), commitmentId));

            return new Commitment(commitmentId, habit, CommitmentStatus.Pending, lengthInDays, creatorId, reminders);
        }
    }

    public enum CommitmentStatus
    {
        Pending,
        Active,
        Completed,
        Failed,
    }
}
