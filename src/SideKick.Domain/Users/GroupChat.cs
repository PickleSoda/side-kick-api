using SideKick.Domain.Common;

namespace SideKick.Domain.GroupChats
{
    public class GroupChat : Entity
    {
        public List<Guid> ParticipantIds { get; private set; }
        public List<Message> Messages { get; private set; }

        public GroupChat(Guid id)
            : base(id)
        {
            ParticipantIds = new List<Guid>();
            Messages = new List<Message>();
        }

        public void AddParticipant(Guid userId)
        {
            ParticipantIds.Add(userId);
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
    }

    public class Message
    {
        public Guid UserId { get; private set; }
        public string Text { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Message(Guid userId, string text, DateTime timestamp)
        {
            UserId = userId;
            Text = text;
            Timestamp = timestamp;
        }
    }
}
