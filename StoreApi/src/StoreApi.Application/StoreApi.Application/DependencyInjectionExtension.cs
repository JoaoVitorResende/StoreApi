using Microsoft.Extensions.DependencyInjection;
using StoreApi.Application.AutoMapper;
using StoreApi.Application.UseCases.Category.Get;
using StoreApi.Application.UseCases.Category.Register;
using StoreApi.Application.UseCases.Itens.GetAll;
using StoreApi.Application.UseCases.Itens.GetByID;
using StoreApi.Application.UseCases.Itens.Register;
using StoreApi.Application.UseCases.Purchases;
using StoreApi.Application.UseCases.Purchases.StoreApi.Application.UseCases.Purchases.ProcessCreated;
using StoreApi.Application.UseCases.Store.GetAll;
using StoreApi.Application.UseCases.Store.GetByName;
using StoreApi.Application.UseCases.Store.Register;

namespace StoreApi.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
        }
        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }
        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterItemUseCase, RegisterItemUseCase>();
            services.AddScoped<IRegisterCategoryUseCase, RegisterCategoryUseCase>();
            services.AddScoped<IRegisterStoreUseCase, RegisterStoreUseCase>();
            services.AddScoped<IGetAllItens, GetAllItens>();
            services.AddScoped<IGetItemByID, GetItemByID>();
            services.AddScoped<IGetCategories, GetCategories>();
            services.AddScoped<IGetStoreByName, GetStoreByName>();
            services.AddScoped<IGetStoreAll, GetStoreAll>();
            services.AddScoped<IProcessPurchaseCreatedUseCase, ProcessPurchaseCreatedUseCase>();
        }
    }
}
