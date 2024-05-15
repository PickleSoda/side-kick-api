namespace SideKick.Contracts.Reminders;

public record CreateReminderRequest(string Text, DateTimeOffset DateTime);