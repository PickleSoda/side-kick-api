using SideKick.Domain.ReminderSchedules;
using SideKick.Domain.ReminderSchedules.ReminderTypes;

namespace SideKick.Application.ReminderSchedules.Common
{
    public record ReminderScheduleResult(
        Guid Id,
        string TextTemplate,
        TimeOnly Time,
        bool RequiresConfirmation,
        bool IsActive,
        int Priority,
        int DayIndex,
        ReminderType ReminderType,
        int? DayOfCommitment,
        bool Mon,
        bool Tue,
        bool Wed,
        bool Thu,
        bool Fri,
        bool Sat,
        bool Sun)
    {
        public static ReminderScheduleResult FromReminderSchedule(ReminderSchedule reminderSchedule)
        {
            return new ReminderScheduleResult(
                reminderSchedule.Id,
                reminderSchedule.TextTemplate,
                reminderSchedule.Time,
                reminderSchedule.RequiresConfirmation,
                reminderSchedule.IsActive,
                reminderSchedule.Priority,
                reminderSchedule.DayIndex,
                reminderSchedule.ReminderType,
                reminderSchedule.DayOfCommitment,
                reminderSchedule.Mon,
                reminderSchedule.Tue,
                reminderSchedule.Wed,
                reminderSchedule.Thu,
                reminderSchedule.Fri,
                reminderSchedule.Sat,
                reminderSchedule.Sun);
        }
    }
}
