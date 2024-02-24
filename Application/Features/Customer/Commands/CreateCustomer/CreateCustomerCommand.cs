using CQRS_Shop.Application.Dto;
using CQRS_Shop.Application.Features.Customer.Responses;
using MediatR;

namespace CQRS_Shop.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<CustomerResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DocumentDto Document { get; set; }
}