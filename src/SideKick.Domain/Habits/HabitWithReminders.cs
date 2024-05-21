using SideKick.Domain.ReminderSchedules;
namespace SideKick.Domain.Habits
{
    public class HabitWithReminders
    {
        public HabitWithReminders(Habit habit, List<ReminderSchedule> reminders)
        {
            Habit = habit;
            Reminders = reminders;
        }

        public Habit Habit { get; set; }
        public List<ReminderSchedule> Reminders { get; set; } = new List<ReminderSchedule>();
    }
}