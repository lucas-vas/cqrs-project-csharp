namespace CQRS_Shop.Domain.ValueObjects;

public class Document {
    public string Type { get; private set; }
    public string Description { get; private set; }

    public Document(
        string type,
        string description
    )
    {
        Type = type;
        Description = description;
    }
}