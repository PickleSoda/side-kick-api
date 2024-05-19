using SideKick.Domain.Habits;

namespace SideKick.Application.Common.Interfaces
{
    public interface IHabitsRepository
    {
        // Add a new Habit to the repository
        Task AddAsync(Habit habit, CancellationToken cancellationToken);

        // Retrieve a Habit by its unique identifier
        Task<Habit?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        // Retrieve all Habits, optionally including related entities such as Reminders
        Task<List<Habit>> GetAllAsync(CancellationToken cancellationToken);

        // Update an existing Habit in the repository
        Task UpdateAsync(Habit habit, CancellationToken cancellationToken);

        // Delete a Habit from the repository
        Task RemoveAsync(Habit habit, CancellationToken cancellationToken);

        // Additional methods can be added below if needed for specific business logic

        // Example: Retrieve Habits with their associated Reminders filtered by some criteria
        // Task<List<Habit>> GetHabitsWithRemindersAsync(CancellationToken cancellationToken);

        // Example: Remove a specific Reminder from a Habit
        // Task RemoveReminderFromHabitAsync(Guid habitId, Guid reminderId, CancellationToken cancellationToken);
    }
}
