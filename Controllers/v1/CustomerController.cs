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
        return Ok(Mediator.Send(query));
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetCustomerByIdQuery query){
        return Ok(Mediator.Send(query));
    }
}
