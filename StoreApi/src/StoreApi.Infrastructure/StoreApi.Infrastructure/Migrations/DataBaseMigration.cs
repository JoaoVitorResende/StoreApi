using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreApi.Infrastructure.DataAccess.mongo;
using StoreApi.Infrastructure.DataAccess.Postgres;

namespace StoreApi.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public async static Task MigrateDataBase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            // Postgres: aplica as migrations pendentes (cria o banco se não existir)
            var postgres = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            await postgres.Database.MigrateAsync();

            // Mongo: não há migrations, só os índices
            var mongo = scope.ServiceProvider.GetRequiredService<MongoContext>();
            await mongo.EnsureIndexesAsync();
        }
    }
}
