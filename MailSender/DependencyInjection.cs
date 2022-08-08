using MailSender.Service;
using Microsoft.Extensions.DependencyInjection;

namespace MailSender
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMailSender(this IServiceCollection services) => services.AddTransient<IMailService, MailService>();
    }
}