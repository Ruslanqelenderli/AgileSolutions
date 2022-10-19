using AgileSolutions.Business.Concrete.Dtos.DepartmentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Helpers.Validators.DepartmentValidators
{
    public class DepartmentUpdateValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Please add id.");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");

        }
    }
}
