namespace SideKick.Application.Common.Interfaces;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}