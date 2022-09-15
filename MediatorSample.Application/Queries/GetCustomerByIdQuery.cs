using MediatorSample.Domain.Entities;
using MediatorSample.Domain.Interfaces;
using MediatR;

namespace MediatorSample.Application.Queries;

public class GetCustomerByIdQuery : IRequest<Customer?>
{
    public int Id { get; set; }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));

            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Customer?> Handle(GetCustomerByIdQuery getCustomerByIdQuery, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(getCustomerByIdQuery.Id);

            if (customer == null)
            {
                return default;
            }

            return customer;
        }
    }
}