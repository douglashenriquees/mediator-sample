using MediatorSample.Domain.Interfaces;
using MediatR;

namespace MediatorSample.Application.Commands;

public class UpdateCustomerCommand : IRequest<int>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));

            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<int> Handle(UpdateCustomerCommand updateCustomerCommand, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(updateCustomerCommand.Id);

            if (customer == null)
            {
                return default;
            }

            customer.Name = updateCustomerCommand.Name;
            customer.Email = updateCustomerCommand.Email;

            await _customerRepository.Update(customer);

            return customer.Id;
        }
    }
}