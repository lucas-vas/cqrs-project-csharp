using CQRS_Shop.Domain.ValueObjects;

namespace CQRS_Shop.Application.Features.Customer.Responses;

public class CustomerResponse{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Document Document { get; set; }
}
