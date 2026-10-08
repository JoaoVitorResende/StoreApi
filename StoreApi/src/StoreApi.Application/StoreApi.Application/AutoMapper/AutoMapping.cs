using AutoMapper;
using StoreApi.Communication.Category.Request;
using StoreApi.Communication.Category.Response;
using StoreApi.Communication.Item.Request;
using StoreApi.Communication.Item.Response;
using StoreApi.Communication.Store.Request;
using StoreApi.Communication.Store.Response;
using StoreApi.Domain.Entities;

namespace StoreApi.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestEntity();
            EntityToResponse();
        }
        private void RequestEntity()
        {
            CreateMap<RequestItemJson, Item>();
            CreateMap<RequestCategoryJson, Category>();
            CreateMap<RequestStoreJson, Store>();
        }
        private void EntityToResponse()
        {
            CreateMap<Item, ResponseRegisterItemJson>();
            CreateMap<Category, ResponseRegisterCategoryJson>();
            CreateMap<Store, ResponseRegisterStoreJson>();
        }
    }
}
