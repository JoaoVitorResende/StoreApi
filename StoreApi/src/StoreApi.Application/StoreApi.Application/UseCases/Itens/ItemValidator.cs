using FluentValidation;
using StoreApi.Communication.Item.Request;

namespace StoreApi.Application.UseCases.Itens
{
    public class ItemValidator : AbstractValidator<RequestItemJson>
    {
        public ItemValidator()
        {
            RuleFor(store => store.Title).NotEmpty().WithMessage("Titulo do item não pode ser vazio");
            RuleFor(store => store.Description).NotEmpty().WithMessage("Descrição não pode ser vazio");
            RuleFor(store => store.Quantity).NotEmpty().WithMessage("A quantidade não pode sair");
            RuleFor(store => store.Price).GreaterThan(0).WithMessage("O preço não pode ser menor que zero ou igual a zero");
            RuleFor(store => store.CategoryId).NotEmpty().WithMessage("O id de categoria não pode ser vazio");
            RuleFor(store => store.StoreId).NotEmpty().WithMessage("O id de loja não pode ser vazio");
        }
    }
}
