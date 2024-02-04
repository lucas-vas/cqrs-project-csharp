using CQRS_Shop.Application.Features.Customer.Responses;
using MediatR;

namespace CQRS_Shop.Application.Features.Customer.Queries.GetCustomerById;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>{
    public GetCustomerByIdHandler()
    {
    }

    public Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}