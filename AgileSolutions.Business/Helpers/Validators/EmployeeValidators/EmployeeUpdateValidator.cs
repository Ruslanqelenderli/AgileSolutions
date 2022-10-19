using AgileSolutions.Business.Concrete.Dtos.EmployeeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Helpers.Validators.EmployeeValidators
{
    public class EmployeeUpdateValidator : AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Please add id.");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 character");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Maximum 20 character");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Please add surname.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Minimum 3 character");
            RuleFor(x => x.Surname).MaximumLength(20).WithMessage("Maximum 20 character");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Please add email.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please add correct email.");
        }
    }
}
