using FluentValidation;
using Tec.Web.Models.Catalog;
using Tec.Web.Repositories;

namespace Tec.Web.Validators.Catalog
{
    public partial class ProductValidator : AbstractValidator<Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Name).Length(1, 50).MustAsync(async (name, cancellation) =>
            {
                bool exists = await _unitOfWork.Products.AnyAsync(p => p.Name == name);
                return !exists;
            }).WithMessage("The {PropertyName}: {PropertyValue} already exists!");
            RuleFor(p => p.Sku).Length(1, 50).MustAsync(async (sku, cancellation) =>
            {
                bool exists = await _unitOfWork.Products.AnyAsync(p => p.Sku == sku);
                return !exists;
            }).WithMessage("The {PropertyName}: {PropertyValue} already exists!");

            RuleForEach(p => p.Combinations).SetValidator(new CombinationValidator());
        }
    }
}