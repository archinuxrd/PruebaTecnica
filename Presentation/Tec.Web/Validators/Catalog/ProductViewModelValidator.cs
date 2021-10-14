using FluentValidation;
using Tec.Web.Models.Catalog;
using Tec.Web.Repositories;

namespace Tec.Web.Validators.Catalog
{
    public partial class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductViewModelValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(p => p.Id).NotNull().WithMessage("The {PropertyName} field is required.");
            RuleFor(p => p.Name).Length(1, 50).NotNull().MustAsync(async (name, cancellation) =>
            {
                bool exists = await _unitOfWork.Products.AnyAsync(p => p.Name == name);
                return !exists;
            }).WithMessage("The {PropertyName}: {PropertyValue} already exists!");
            RuleFor(p => p.Sku).Length(1, 50).NotNull().MustAsync(async (sku, cancellation) =>
            {
                bool exists = await _unitOfWork.Products.AnyAsync(p => p.Sku == sku);
                return !exists;
            }).WithMessage("The {PropertyName}: {PropertyValue} already exists!");
            RuleForEach(p => p.Combinations).NotNull().SetValidator(new CombinationValidator());
        }
    }
}