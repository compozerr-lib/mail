using Core.MediatR;
using Mail.Services;
using MediatR;

namespace Mail.Endpoints.Mail.SendMail;

public sealed class SendMailCommandHandler(
	IMailService mailService) : ICommandHandler<SendMailCommand>
{
	public Task Handle(SendMailCommand command, CancellationToken cancellationToken = default)
	{
		var email = new Email(
			   command.From,
			   [command.To],
			   command.Subject,
			   command.HtmlBody);

		return mailService.SendEmailAsync(email);
	}
}
