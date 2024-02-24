using CQRS_Shop.Application.Features.Customer.Responses;
using MediatR;

namespace CQRS_Shop.Application.Features.Customer.Queries.GetCustomerById;

public class GetCustomerByIdQuery(int id) : IRequest<CustomerResponse>{
    public int Id { get; private set; } = id;
}