using System;
using System.Collections.Generic;
using SideKick.Domain.Habits;
using TestCommon.ReminderSchedules;
using TestCommon.TestConstants;

namespace TestCommon.Habits
{
    public static class HabitFactory
    {
        public static Habit CreateHabit(
            Guid? id = null,
            string name = Constants.Habit.Name,
            string description = Constants.Habit.Description,
            List<Guid>? reminderIds = null)
        {
            var habit = new Habit(
                id ?? Constants.Habit.Id,
                name,
                description);

            if (reminderIds != null)
            {
                foreach (var reminderId in reminderIds)
                {
                    var reminder = ReminderScheduleFactory.CreateOneTimeReminder(id: reminderId);
                    habit.AddReminder(reminder);
                }
            }
            else
            {
                var reminder = ReminderScheduleFactory.CreateOneTimeReminder();
                habit.AddReminder(reminder);
            }

            return habit;
        }
    }
}
