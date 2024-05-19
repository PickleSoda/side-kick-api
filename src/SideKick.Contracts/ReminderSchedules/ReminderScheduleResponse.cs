using SideKick.Contracts.Common;

namespace SideKick.Contracts.ReminderSchedules;

public record ReminderScheduleResponse(
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
    bool Sun);
