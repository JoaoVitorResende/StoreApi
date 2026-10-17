using MassTransit;
using StoreApi.Api.Messaging;

namespace StoreApi.Api.Extensions
{
    public static class MessagingExtension
    {
        public static void AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            var host = configuration["RabbitMq:Host"];
            if (string.IsNullOrWhiteSpace(host))
                throw new InvalidOperationException("RabbitMq:Host não configurado.");

            var user = configuration["RabbitMq:User"] ?? "guest";
            var pass = configuration["RabbitMq:Password"] ?? "guest";

            services.AddMassTransit(x =>
            {
                x.AddConsumer<PurchaseCreatedConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(host, "/", h =>
                    {
                        h.Username(user);
                        h.Password(pass);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
