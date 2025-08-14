namespace Mail;

public record Email(
    EmailAddress From,
    IReadOnlyList<EmailAddress> To,
    string Subject,
    string HtmlBody);