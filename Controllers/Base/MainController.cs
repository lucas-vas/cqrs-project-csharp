using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Shop.Controllers.Base;

[ApiController]
public class MainController : ControllerBase{

    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}