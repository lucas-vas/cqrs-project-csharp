using CQRS_Shop.Application.Features.Customer.Responses;
using Entities = CQRS_Shop.Domain.Entities;
using CQRS_Shop.Infra.Data.InterfacesRepositories;
using MediatR;

namespace CQRS_Shop.Application.Features.Customer.Queries.GetCustomerById;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdHandler
    (
        ICustomerRepository customerRepository
    )
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.Id);
        if(customer is not null){
            var customerResponse = MapCustomerResponse(customer);
            return customerResponse;
        }

        throw new BadHttpRequestException(statusCode: 400, message: "Customer not found.");
    }


    private CustomerResponse MapCustomerResponse(Entities.Customer customer){
        var customerResponse = new CustomerResponse(){
            Id = customer.Id,
            Document  = customer.Document,
            Email = customer.Email,
            Name = customer.Name
        };

        return customerResponse;
    }
}