using CQRS_Shop.Application.Features.Customer.Responses;
using CQRS_Shop.Infra.Data.InterfacesRepositories;
using Entities = CQRS_Shop.Domain.Entities;
using MediatR;

namespace CQRS_Shop.Application.Features.Customer.Queries.GetAllCustomer;

public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerResponse>> {

    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomerHandler(
        ICustomerRepository customerRepository
    )
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerResponse>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var listCustomer = _customerRepository.GetAll();
        var listCustomerResponse = MapCustomerResponse(listCustomer);

        return listCustomerResponse;
    }

    private List<CustomerResponse> MapCustomerResponse(List<Entities.Customer> customers){
        var listCustomerResponse = customers.Select(x => new CustomerResponse(){
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Document = x.Document
        }).ToList();

        return listCustomerResponse;
    }
}