using System;
using System.Collections.Generic;
using SideKick.Domain.Habits;
using SideKick.Domain.Reminders;
using TestCommon.Reminders;
using TestCommon.TestConstants;
namespace TestCommon.Habits
{
       public static class HabitFactory
    {
        public static Habit CreateHabit(
            Guid? id = null,
            string name = Constants.Habit.Name,
            string description = Constants.Habit.Description,
            List<Reminder>? reminders = null)
        {
            return new Habit(
                id ?? Constants.Habit.Id,
                name,
                description,
                reminders ?? new List<Reminder> { ReminderFactory.CreateReminder() });
        }
    }
}
