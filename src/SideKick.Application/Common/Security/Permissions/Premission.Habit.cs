namespace SideKick.Application.Common.Security.Permissions;

public static partial class Permission
{
    public static class Habit
    {
        public const string Create = "create:habit";
        public const string Read = "read:habit";
        public const string Update = "update:habit";
        public const string Delete = "delete:habit";
    }
}
