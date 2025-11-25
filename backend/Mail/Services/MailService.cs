using Mail.Events;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Mail.Services;

public class MailService(
    IPublisher publisher) : IMailService
{
    public Task SendEmailAsync(Email email)
        => publisher.Publish(
            new SendEmailEvent(email));
}
