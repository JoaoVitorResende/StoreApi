using FluentValidation;
using StoreApi.Communication.Category.Request;

namespace StoreApi.Application.UseCases.Category
{
    public class CategoryValidator : AbstractValidator<RequestCategoryJson>
    {
        public CategoryValidator()
        {
            RuleFor(store => store.Name).NotEmpty().WithMessage("O nome não pode ser vazio");
        }
    }
}
