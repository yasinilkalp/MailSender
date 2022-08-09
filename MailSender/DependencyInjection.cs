using MailSender.Service.Mail;
using MailSender.Service.Template;
using Microsoft.Extensions.DependencyInjection;

namespace MailSender
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMailSender(this IServiceCollection services)
        { 
            services.AddSingleton<IMailService, MailService>();
            services.AddSingleton(typeof(ITemplateService<>), typeof(TemplateService<>));

            return services;
        }
    }
}