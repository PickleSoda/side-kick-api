using System;
using SideKick.Domain.ReminderSchedules;

namespace TestCommon.ReminderSchedules
{
    public static class ReminderScheduleFactory
    {
        public static ReminderSchedule CreateOneTimeReminder(
            Guid? id = null,
            string textTemplate = "Default Text Template",
            TimeOnly time = default,
            bool requiresConfirmation = false,
            bool isActive = true,
            Guid? habitId = null,
            int dayOfCommitment = 1,
            int priority = 1,
            int dayIndex = 1)
        {
            return ReminderSchedule.CreateOneTimeReminder(
                id ?? Guid.NewGuid(),
                textTemplate,
                time == default ? new TimeOnly(9, 0) : time,
                requiresConfirmation,
                isActive,
                habitId ?? Guid.NewGuid(),
                dayOfCommitment,
                priority,
                dayIndex);
        }

        public static ReminderSchedule CreateRecurrentReminder(
            Guid? id = null,
            string textTemplate = "Default Text Template",
            TimeOnly time = default,
            bool requiresConfirmation = false,
            bool isActive = true,
            Guid? habitId = null,
            bool mon = true,
            bool tue = true,
            bool wed = true,
            bool thu = true,
            bool fri = true,
            bool sat = true,
            bool sun = true,
            int priority = 1,
            int dayIndex = 1)
        {
            return ReminderSchedule.CreateRecurrentReminder(
                id ?? Guid.NewGuid(),
                textTemplate,
                time == default ? new TimeOnly(9, 0) : time,
                requiresConfirmation,
                isActive,
                habitId ?? Guid.NewGuid(),
                mon,
                tue,
                wed,
                thu,
                fri,
                sat,
                sun,
                priority,
                dayIndex);
        }
    }
}
