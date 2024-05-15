using SideKick.Domain.Common;
using SideKick.Domain.Reminders;

namespace SideKick.Domain.Habits
{
    public class Habit : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Reminder> Reminders { get; private set; }

        public Habit(Guid id, string name, string description, List<Reminder> reminders)
            : base(id)
        {
            Name = name;
            Description = description;
            Reminders = reminders;
        }
    }
}
