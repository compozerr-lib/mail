using Mail.Events;
using MediatR;

namespace Mail.Services;

public interface IMailService
{
    Task SendEmailAsync(Email email);
}

public class MailService(IPublisher publisher) : IMailService
{
    public Task SendEmailAsync(Email email)
        => publisher.Publish(
            new SendEmailEvent(email));
}
