using CQRS_Shop.Application.Features.Customer.Responses;
using CQRS_Shop.Infra.Data.InterfacesRepositories;
using Entites = CQRS_Shop.Domain.Entities;
using MediatR;
using CQRS_Shop.Domain.ValueObjects;
using CQRS_Shop.Infra.Data.Integration.Interfaces;

namespace CQRS_Shop.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerHandler
(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork
)
 : IRequestHandler<CreateCustomerCommand, CustomerResponse>
{
    public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Entites.Customer
                           (
                               name: request.Name,
                               email: request.Email,
                               document: new Document
                                             (
                                                type: request.Document.Type,
                                                description: request.Document.Description
                                             )
                           );

        await customerRepository.Insert(customer);
        await unitOfWork.CommitAsync(cancellationToken);

        var response = MapearCustomerResponse(customer);
        return response;
    }

    private CustomerResponse MapearCustomerResponse(Entites.Customer customer){
        var customerResponse = new CustomerResponse{
            Id = customer.Id,
            Email = customer.Email,
            Name = customer.Name,
            Document = customer.Document
        };

        return customerResponse;
    }
}