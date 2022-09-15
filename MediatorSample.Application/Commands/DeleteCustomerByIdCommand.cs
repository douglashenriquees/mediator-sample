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
                return default;
            }

            await _customerRepository.Remove(customer);

            return customer.Id;
        }
    }
}