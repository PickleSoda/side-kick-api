namespace SideKick.Contracts.Habits;

public record AddReminderToHabitRequest(
    string TextTemplate,
    DateTime ReminderTime,
    string ReminderType, // "OneTime" or "Recurrent"
    bool RequiresConfirmation,
    bool IsActive,
    int Priority,
    int DayIndex,
    int? DayOfCommitment = null,
    bool? Mon = null,
    bool? Tue = null,
    bool? Wed = null,
    bool? Thu = null,
    bool? Fri = null,
    bool? Sat = null,
    bool? Sun = null);
