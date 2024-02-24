using CQRS_Shop.Application.Features.Customer.Commands.CreateCustomer;
using CQRS_Shop.Application.Features.Customer.Queries.GetAllCustomer;
using CQRS_Shop.Application.Features.Customer.Queries.GetCustomerById;
using CQRS_Shop.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Shop.Controllers.v1;

[Route("api/v1/[controller]")]
public class CustomerController : MainController
{
    public CustomerController()
    {
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCustomerQuery();
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id){
        var query = new GetCustomerByIdQuery(id: id);
        return Ok(await Mediator.Send(query));
    }

    [HttpPost("CreateCustomer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command){
        return Ok(await Mediator.Send(command));
    }
}
