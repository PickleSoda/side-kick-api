using SideKick.Domain.GroupChats;

namespace SideKick.Domain.UnitTests.GroupChats
{
    public class GroupChatTests
    {
        [Fact]
        public void CreateGroupChat_WhenConstructed_ShouldHaveNoParticipants()
        {
            // Act
            var groupChat = GroupChatFactory.CreateGroupChat();

            // Assert
            groupChat.ParticipantIds.Should().BeEmpty();
        }

        [Fact]
        public void AddParticipant_WhenCalled_ShouldAddParticipant()
        {
            // Arrange
            var groupChat = GroupChatFactory.CreateGroupChat();
            var userId = Guid.NewGuid();

            // Act
            groupChat.AddParticipant(userId);

            // Assert
            groupChat.ParticipantIds.Should().Contain(userId);
        }

        [Fact]
        public void AddMessage_WhenCalled_ShouldAddMessage()
        {
            // Arrange
            var groupChat = GroupChatFactory.CreateGroupChat();
            var message = new Message(Guid.NewGuid(), "Hello, World!", DateTime.UtcNow);

            // Act
            groupChat.AddMessage(message);

            // Assert
            groupChat.Messages.Should().Contain(message);
        }
    }
}
