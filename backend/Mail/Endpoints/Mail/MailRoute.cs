using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Mail.Services;

namespace Mail.Endpoints.Mail;

public static class MailRoute
{
    public static RouteHandlerBuilder AddMailRoute(this IEndpointRouteBuilder app)
    {
        return app.MapGet("/", (string name, IMailService mailService) => new GetMailResponse($"Hello, {mailService.GetObfuscatedName(name)}!"));
    }
}