namespace CQRS_Shop.Domain.ValueObjects;

public class Contact
{
    public string PhoneNumber { get; private set; }
    public string Ddd { get; private set; }
    public char DefaultContact { get; private set; }
    public string Email { get; private set; }

    public Contact
    (
        string phoneNumber,
        string ddd,
        char defaultContact,
        string email
    )
    {
        PhoneNumber = phoneNumber;
        Ddd = ddd;
        DefaultContact = char.ToUpper(defaultContact);
        Email = email;
    }
}