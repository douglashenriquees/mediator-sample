using MediatorSample.Application.Notifications;
using MediatorSample.Domain.Interfaces;
using MediatR;

namespace MediatorSample.Application.Commands;

public class DeleteCustomerByIdCommand : IRequest<int>
{
    public int Id { get; set; }

    public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public DeleteCustomerByIdCommandHandler(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));

            _mediator = mediator
                ?? throw new ArgumentException(nameof(mediator));
        }

        public async Task<int> Handle(DeleteCustomerByIdCommand deleteCustomerByIdCommand, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(deleteCustomerByIdCommand.Id);

            if (customer == null)
            {
                await _mediator.Publish(new ErrorNotification()
                {
                    Error = "Customer not found",
                    Stack = "Customer is null"
                }, cancellationToken);

                return default;
            }

            await _customerRepository.Remove(customer);

            await _mediator.Publish(new CustomerActionNotification()
            {
                Name = customer.Name,
                Email = customer.Email,
                Action = ActionNotificationEnum.Deleted
            }, cancellationToken);

            return customer.Id;
        }
    }
}