using SideKick.Domain.GroupChats;
using TestCommon.TestConstants;

namespace TestCommon.GroupChats
{
    public static class GroupChatFactory
    {
        public static GroupChat CreateGroupChat(Guid? id = null)
        {
            return new GroupChat(id ?? Guid.NewGuid());
        }
    }
}
