using TestCommon.ReminderSchedules;
using Xunit;

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
            var reminders = habit.GetReminders();
            reminders.Should().NotBeNull();
            reminders.Should().NotBeEmpty();
        }

        [Fact]
        public void CreateHabit_WhenConstructed_ShouldHaveCorrectReminderDetails()
        {
            // Arrange
            var reminderId = Guid.NewGuid();
            var habit = HabitFactory.CreateHabit(reminderIds: new List<Guid> { reminderId });

            // Act
            var reminders = habit.GetReminders();
            var reminder = reminders.FirstOrDefault(r => r == reminderId);

            // Assert
            reminder.Should().NotBe(Guid.Empty);

            var reminderDetails = ReminderScheduleFactory.CreateOneTimeReminder(id: reminderId);

            reminderDetails.TextTemplate.Should().Be("Default Text Template");
            reminderDetails.Time.Should().Be(new TimeOnly(9, 0));
            reminderDetails.RequiresConfirmation.Should().BeFalse();
            reminderDetails.IsActive.Should().BeTrue();
            reminderDetails.DayOfCommitment.Should().Be(1);
            reminderDetails.Priority.Should().Be(1);
            reminderDetails.DayIndex.Should().Be(1);
        }
    }
}
