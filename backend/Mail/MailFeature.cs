using Core.Feature;
using Microsoft.Extensions.DependencyInjection;
using Mail.Services;

namespace Mail;

public class MailFeature : IFeature
{

    void IFeature.ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IMailService, MailService>();
    }
}