using MediatorSample.Application.Notifications;
using MediatR;

namespace MediatorSample.Application.Events;

public class LogEventHandler :
    INotificationHandler<CustomerActionNotification>,
    INotificationHandler<ErrorNotification>
{
    public Task Handle(CustomerActionNotification customerActionNotification, CancellationToken cancellationToken)
    {
        return Task.Run(() => Console.WriteLine($"Customer {customerActionNotification.Name} - {customerActionNotification.Email} was {customerActionNotification.Action.ToString().ToLower()} successfuly"));
    }

    public Task Handle(ErrorNotification errorNotification, CancellationToken cancellationToken)
    {
        return Task.Run(() => Console.WriteLine($"ERROR: '{errorNotification.Error}' \n {errorNotification.Stack}"));
    }
}