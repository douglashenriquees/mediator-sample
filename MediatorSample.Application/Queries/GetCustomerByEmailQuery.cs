using MediatorSample.Domain.Entities;
using MediatorSample.Domain.Interfaces;
using MediatR;

namespace MediatorSample.Application.Queries;

public class GetCustomerByEmailQuery : IRequest<Customer?>
{
    public string Email { get; set; } = string.Empty;

    public class GetCustomerByEmailQueryHandler : IRequestHandler<GetCustomerByEmailQuery, Customer?>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public GetCustomerByEmailQueryHandler(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));

            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Customer?> Handle(GetCustomerByEmailQuery getCustomerByEmailQuery, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByEmail(getCustomerByEmailQuery.Email);

            if (customer == null)
            {
                return default;
            }

            return customer;
        }
    }
}