using SideKick.Domain.Commitments;
using SideKick.Domain.Habits;
using SideKick.Domain.Reminders;
using TestCommon.TestConstants;

namespace TestCommon.Commitments
{
    public static class CommitmentFactory
    {
        public static Commitment CreateCommitment(
            Guid? id = null,
            Habit? targetHabit = null,
            CommitmentStatus status = CommitmentStatus.Pending,
            int lengthInDays = 30,
            Guid? creatorId = null,
            List<Reminder>? reminders = null)
        {
            return new Commitment(
                id ?? Guid.NewGuid(),
                targetHabit ?? new Habit(Constants.Habit.Id, Constants.Habit.Name, Constants.Habit.Description),
                status,
                lengthInDays,
                creatorId ?? Constants.User.Id,
                reminders ?? new List<Reminder>());
        }
    }
}
