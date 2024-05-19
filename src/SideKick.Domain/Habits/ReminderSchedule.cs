using SideKick.Domain.Common;
using SideKick.Domain.ReminderSchedules.ReminderTypes;
namespace SideKick.Domain.ReminderSchedules
{
    public class ReminderSchedule : Entity
    {
        public string TextTemplate { get; set; } = null!;
        public TimeOnly Time { get; set; }
        public bool RequiresConfirmation { get; set; }
        public bool IsActive { get; set; }
        public Guid HabitId { get; set; }
        public ReminderType ReminderType { get; }
        public int Priority { get; set; }
        public int DayIndex { get; set; }

        public ReminderSchedule(
            ReminderType reminderType,
            Guid id,
            string textTemplate,
            TimeOnly time,
            bool requiresConfirmation,
            bool isActive,
            Guid habitId,
            int priority,
            int dayIndex)
            : base(id)
        {
            ReminderType = reminderType;
            TextTemplate = textTemplate;
            Time = time;
            RequiresConfirmation = requiresConfirmation;
            IsActive = isActive;
            HabitId = habitId;
            Priority = priority;
            DayIndex = dayIndex;
        }

        public static ReminderSchedule CreateOneTimeReminder(
            Guid id,
            string textTemplate,
            TimeOnly time,
            bool requiresConfirmation,
            bool isActive,
            Guid habitId,
            int dayOfCommitment,
            int priority,
            int dayIndex)
        {
            return new ReminderSchedule(
                ReminderType.OneTime,
                id,
                textTemplate,
                time,
                requiresConfirmation,
                isActive,
                habitId,
                priority,
                dayIndex)
            {
                DayOfCommitment = dayOfCommitment,
            };
        }

        public static ReminderSchedule CreateRecurrentReminder(
            Guid id,
            string textTemplate,
            TimeOnly time,
            bool requiresConfirmation,
            bool isActive,
            Guid habitId,
            bool mon,
            bool tue,
            bool wed,
            bool thu,
            bool fri,
            bool sat,
            bool sun,
            int priority,
            int dayIndex)
        {
            return new ReminderSchedule(
                ReminderType.Recurrent,
                id,
                textTemplate,
                time,
                requiresConfirmation,
                isActive,
                habitId,
                priority,
                dayIndex)
            {
                Mon = mon,
                Tue = tue,
                Wed = wed,
                Thu = thu,
                Fri = fri,
                Sat = sat,
                Sun = sun,
            };
        }

        public bool Mon { get; private set; }
        public bool Tue { get; private set; }
        public bool Wed { get; private set; }
        public bool Thu { get; private set; }
        public bool Fri { get; private set; }
        public bool Sat { get; private set; }
        public bool Sun { get; private set; }
        public int DayOfCommitment { get; private set; }
    }
}
