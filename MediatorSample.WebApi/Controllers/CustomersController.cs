using MediatorSample.Application.Commands;
using MediatorSample.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorSample.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    // sem services
    // sem repositorys
    // apenas o Mediator

    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand createCustomerCommand)
    {
        var result = await _mediator.Send(createCustomerCommand);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCustomerCommand updateCustomerCommand)
    {
        if (id != updateCustomerCommand.Id)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(updateCustomerCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var result = await _mediator.Send(new DeleteCustomerByIdCommand() { Id = id });

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomersQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery() { Id = id });

        return Ok(result);
    }

    [HttpGet("get-by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] GetCustomerByEmailQuery getCustomerByEmailQuery)
    {
        var result = await _mediator.Send(getCustomerByEmailQuery);

        return Ok(result);
    }
}