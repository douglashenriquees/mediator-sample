using MediatR;

namespace MediatorSample.Application.Notifications;

public class ErrorNotification : INotification
{
    public string Error { get; set; } = string.Empty;

    public string Stack { get; set; } = string.Empty;
}