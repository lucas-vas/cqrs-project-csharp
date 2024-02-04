using CQRS_Shop.Domain.Base;

namespace CQRS_Shop.Domain.Entities;

public class Order : BaseEntity{
    public int Id { get; private set; }
    public string Number { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }

    protected Order(){}

    public Order(
        int id,
        string number,
        int customerId,
        Customer customer
    )
    {
        Id = id;
        Number = number;
        CustomerId = customerId;
        Customer = customer;

        Validate();
    }

    protected override void Validate()
    {
        var errors = new List<string>();

        errors.AddRange(string.IsNullOrEmpty(Number) ? new[] { "O campo Number não pode estar vazio." } : Enumerable.Empty<string>());
        errors.AddRange(CustomerId.Equals(null) ? new[] { "O campo CustomerId não pode estar vazio." } : Enumerable.Empty<string>());
        errors.AddRange(Customer is null ? new[] { "O campo Customer não pode estar vazio" } : Enumerable.Empty<string>()
        );

        base.Validate();
    }
}