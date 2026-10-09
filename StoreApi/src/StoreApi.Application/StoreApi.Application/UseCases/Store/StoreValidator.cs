using FluentValidation;
using StoreApi.Communication.Store.Request;

namespace StoreApi.Application.UseCases.Store
{
    public class StoreValidator : AbstractValidator<RequestStoreJson>
    {
        public StoreValidator()
        {
            RuleFor(store => store.Title).NotEmpty().WithMessage("Titulo da loja não pode ser vazio");
            RuleFor(store => store.Address).NotEmpty().WithMessage("O endereço não pode ser vazio");
        }
    }
}
