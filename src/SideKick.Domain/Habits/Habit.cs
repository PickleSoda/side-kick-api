using SideKick.Domain.Common;
using SideKick.Domain.ReminderSchedules;

using SideKick.Domain.Users.Events;

namespace SideKick.Domain.Habits
{
    public class Habit : Entity
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        private readonly List<Guid> _reminderIds = new();

        public Habit(Guid id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }

        public void AddReminder(ReminderSchedule reminder)
        {
            _reminderIds.Add(reminder.Id);
            _domainEvents.Add(new ReminderAddedToHabitEvent(reminder));
        }

        public bool RemoveReminder(Guid reminderId)
        {
            bool removed = _reminderIds.Remove(reminderId);
            if (removed)
            {
                // Assume a method to dispatch domain events
                _domainEvents.Add(new ReminderRemovedFromHabitEvent(reminderId));
            }

            return removed;
        }

        public List<Guid> GetReminders()
        {
            return new List<Guid>(_reminderIds); // Returning a copy to protect encapsulation
        }
    }
}

