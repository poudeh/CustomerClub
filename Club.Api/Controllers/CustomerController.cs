using Club.Api.Infrastructure.Security;
using Club.Application.Customers.AddUserToCustomer;
using Club.Application.Customers.Create;
using Club.Application.Customers.Edit;
using Club.Application.Customers.ToggleActivation;
using Club.Domain.RoleAgg.Enums;
using Club.Queries.Customers.DTOs;
using Club.Queries.Customers.GetByFilter;
using Common.AspNetCore;
using Common.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Club.Api.Controllers;

[PermissionChecker(Permission.Customer_Management)]
public class CustomerController : ApiController
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResult<CustomerFilterResult>> GetCustomers([FromQuery] CustomerFilterParams filterParams)
    {
        var result = await _mediator.Send(new GetCustomerByFilterQuery(filterParams));
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> CreateCustomer(CreateCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> AddUserToCustomer(AddUserToCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> EditCustomer(EditCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> ToggleActivation(ToggleActivationCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

}

