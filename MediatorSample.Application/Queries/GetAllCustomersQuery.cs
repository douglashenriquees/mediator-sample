using MediatorSample.Domain.Entities;
using MediatorSample.Domain.Interfaces;
using MediatR;

namespace MediatorSample.Application.Queries;

public class GetAllCustomersQuery : IRequest<ICollection<Customer>?>
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ICollection<Customer>?>
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IMediator _mediator;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));

            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ICollection<Customer>?> Handle(GetAllCustomersQuery getAllCustomersQuery, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll();

            if (customers == null)
            {
                return default;
            }

            return customers;
        }
    }
}