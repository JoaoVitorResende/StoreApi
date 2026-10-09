using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using StoreApi.Domain.Repositories;
using StoreApi.Domain.Repositories.Categories;
using StoreApi.Domain.Repositories.Items;
using StoreApi.Domain.Repositories.Stores;
using StoreApi.Infrastructure.DataAccess.mongo;
using StoreApi.Infrastructure.DataAccess.Mongo.Repositories;
using StoreApi.Infrastructure.DataAccess.Postgres;
using StoreApi.Infrastructure.DataAccess.Postgres.Repositories;

namespace StoreApi.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IItemReadOnlyRepository, ItemRepository>();
            services.AddScoped<IItemWriteOnlyRepository, ItemRepository>();
            services.AddScoped<IStoreReadOnlyRepository, StoreRepository>();
            services.AddScoped<IStoreWriteOnlyRepository, StoreRepository>();
            services.AddScoped<ICategoryReadOnlyRepository, CategoryRepository>();
            services.AddScoped<ICategoryWriteOnlyRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var postgresConnection = configuration.GetConnectionString("Postgres");
            var mongoConnection = configuration.GetConnectionString("Mongo");
            var mongoDatabase = configuration["Mongo:DatabaseName"];

            if (string.IsNullOrWhiteSpace(postgresConnection)
                || string.IsNullOrWhiteSpace(mongoConnection)
                || string.IsNullOrWhiteSpace(mongoDatabase))
            {
                throw new InvalidOperationException("Configuração de banco de dados ausente.");
            }

            // Postgres (EF Core)
            services.AddDbContext<StoreDbContext>(options => options.UseNpgsql(postgresConnection).UseSnakeCaseNamingConvention());
            // Mongo
            MongoMapping.Register();
            services.AddSingleton<IMongoClient>(new MongoClient(mongoConnection));
            services.AddSingleton(sp => new MongoContext(
                sp.GetRequiredService<IMongoClient>(),
                mongoDatabase));
        }
    }
}