namespace SideKick.Contracts.Habits;

public record HabitResponse(
    Guid Id,
    string Name,
    string Description);

