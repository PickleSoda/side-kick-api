using SideKick.Domain.Commitments;
namespace SideKick.Domain.UnitTests.Commitments
{
    public class CommitmentTests
    {
        [Fact]
        public void CreateCommitment_WhenConstructed_ShouldHavePendingStatus()
        {
            // Act
            var commitment = CommitmentFactory.CreateCommitment();

            // Assert
            commitment.Status.Should().Be(CommitmentStatus.Pending);
        }

        [Fact]
        public void ChangeStatus_WhenCalled_ShouldChangeStatus()
        {
            // Arrange
            var commitment = CommitmentFactory.CreateCommitment();

            // Act
            commitment.ChangeStatus(CommitmentStatus.Active);

            // Assert
            commitment.Status.Should().Be(CommitmentStatus.Active);
        }

        [Fact]
        public void AddReminder_WhenCalled_ShouldAddReminder()
        {
            // Arrange
            var commitment = CommitmentFactory.CreateCommitment();
            var reminder = ReminderFactory.CreateReminder();

            // Act
            commitment.AddReminder(reminder);

            // Assert
            commitment.Reminders.Should().Contain(reminder);
        }
    }
}
