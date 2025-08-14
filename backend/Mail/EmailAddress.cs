namespace Mail;

public sealed class EmailAddress
{
    public string Address { get; }

    public EmailAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Email address cannot be null or empty.", nameof(address));
        if (!address.Contains("@"))
            throw new ArgumentException("Email address must contain '@'.", nameof(address));
        if (!address.Contains('.'))
            throw new ArgumentException("Email address must contain a domain.", nameof(address));

        Address = address;
    }

    public override string ToString() => Address;

    public static implicit operator EmailAddress(string email) => new EmailAddress(email);
}