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

    protected void Validate()
    {
        var errors = new List<string>();

        errors.AddRange(string.IsNullOrEmpty(Number) ? ["The Number field cannot be empty."] : Enumerable.Empty<string>());
        errors.AddRange(CustomerId.Equals(null) ? ["The CustomerId field cannot be empty."] : Enumerable.Empty<string>());
        errors.AddRange(Customer is null ? ["The Customer field cannot be empty."] : Enumerable.Empty<string>()
        );

        base.Validate(errors);
    }
}