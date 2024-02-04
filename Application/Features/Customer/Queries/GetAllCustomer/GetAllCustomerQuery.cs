using CQRS_Shop.Application.Features.Customer.Responses;
using MediatR;

namespace CQRS_Shop.Application.Features.Customer.Queries.GetAllCustomer;

public class GetAllCustomerQuery : IRequest<List<CustomerResponse>>{

}