using CQRS_Shop.Domain.Base;
using CQRS_Shop.Domain.ValueObjects;

namespace CQRS_Shop.Domain.Entities;

public class Customer : BaseEntity {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public Document Document { get; private set; }

    protected Customer(){}

    public Customer(
        int id,
        string name,
        string email,
        Document document
    )
    {
        Id = id;
        Name = name;
        Email = email;
        Document = document;

        Validate();
    }

    protected override void Validate()
    {
        var errors = new List<string>();

        errors.AddRange(string.IsNullOrEmpty(Name) ? new[] { "O campo Name não pode estar vazio." } : Enumerable.Empty<string>());
        errors.AddRange(string.IsNullOrEmpty(Email) ? new[] { "O campo Email não pode estar vazio." } : Enumerable.Empty<string>());
        errors.AddRange(Document is null ? new[] { "O campo Document não pode estar vazio" } : Enumerable.Empty<string>()
        );

        base.Validate();
    }
}