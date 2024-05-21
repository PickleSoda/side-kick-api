using SideKick.Contracts.ReminderSchedules;
namespace SideKick.Contracts.Habits;

public record HabitWithRemindersResponse(
    Guid Id,
    string Name,
    string Description,
    List<ReminderScheduleResponse> Reminders);

