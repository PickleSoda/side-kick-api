namespace SideKick.Domain.UnitTests.Habits
{
    public class HabitTests
    {
        [Fact]
        public void CreateHabit_WhenConstructed_ShouldHaveNameAndDescription()
        {
            // Act
            var habit = HabitFactory.CreateHabit();

            // Assert
            habit.Name.Should().NotBeNullOrEmpty();
            habit.Description.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void CreateHabit_WhenConstructed_ShouldHaveReminders()
        {
            // Act
            var habit = HabitFactory.CreateHabit();

            // Assert
            habit.Reminders.Should().NotBeNull();
            habit.Reminders.Should().NotBeEmpty();
        }
    }
}
