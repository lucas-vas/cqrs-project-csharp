using CQRS_Shop.Domain.Base;
using CQRS_Shop.Domain.ValueObjects;

namespace CQRS_Shop.Domain.Entities;

public class Customer : BaseEntity {
    private List<Order> _orders = new();
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public Document Document { get; private set; }
    public IReadOnlyCollection<Order>? Orders => _orders.AsReadOnly();

    public void Update
    (
        string name,
        string email,
        Document document
    )
    {
        Name = name;
        Email = email;
        Document = document;

        Validate();
    }

    public void AddOrder(Order order){
        _orders.Add(order);
    }

    protected Customer(){}

    public Customer(
        string name,
        string email,
        Document document
    )
    {
        Name = name;
        Email = email;
        Document = document;

        Validate();
    }

    protected void Validate()
    {
        var errors = new List<string>();

        errors.AddRange(string.IsNullOrEmpty(Name) ? ["The Name field cannot be empty."] : Enumerable.Empty<string>());
        errors.AddRange(string.IsNullOrEmpty(Email) ? ["The Email field cannot be empty."] : Enumerable.Empty<string>());
        errors.AddRange(Document is null ? ["The Document field cannot be empty."] : Enumerable.Empty<string>()
        );

        base.Validate(errors);
    }
}