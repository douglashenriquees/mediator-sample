using MediatR;

namespace MediatorSample.Application.Notifications;

public class CustomerActionNotification : INotification
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public ActionNotificationEnum Action { get; set; }
}