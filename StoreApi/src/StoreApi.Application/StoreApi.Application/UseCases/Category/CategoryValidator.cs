using FluentValidation;
using StoreApi.Communication.Category.Request;

namespace StoreApi.Application.UseCases.Category
{
    public class CategoryValidator : AbstractValidator<RequestCategoryJson>
    {
        public CategoryValidator()
        {
            RuleFor(cate => cate.Name).NotEmpty().WithMessage("O nome não pode ser vazio");
        }
    }
}
