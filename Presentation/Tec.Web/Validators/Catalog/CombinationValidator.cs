using FluentValidation;
using Tec.Web.Models.Catalog;

namespace Tec.Web.Validators.Catalog
{
    public partial class CombinationValidator : AbstractValidator<Combination>
    {
        public CombinationValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("The {PropertyName} field is required.");
            RuleFor(x => x.Color).NotEmpty().WithMessage("The {PropertyName} field is required.");
            RuleFor(x => x.UnitPrice).InclusiveBetween(0, 1000000);
            RuleFor(x => x.Quantity).InclusiveBetween(1, 100000);
        }
    }
}