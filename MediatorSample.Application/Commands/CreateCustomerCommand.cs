using MediatorSample.Application.Notifications;
using MediatorSample.Domain.Entities;
using MediatorSample.Domain.Interfaces;
using MediatR;

namespace MediatorSample.Application.Commands;

public class CreateCustomerCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));

            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<int> Handle(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
        {
            var customer = new Customer();

            customer.Name = createCustomerCommand.Name;
            customer.Email = createCustomerCommand.Email;

            await _customerRepository.Add(customer);

            await _mediator.Publish(new CustomerActionNotification()
            {
                Name = createCustomerCommand.Name,
                Email = createCustomerCommand.Email,
                Action = ActionNotificationEnum.Created
            }, cancellationToken);

            return customer.Id;
        }
    }
}