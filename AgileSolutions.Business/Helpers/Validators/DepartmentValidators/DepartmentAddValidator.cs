using AgileSolutions.Business.Concrete.Dtos.DepartmentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Helpers.Validators.DepartmentValidators
{
    public class DepartmentAddValidator : AbstractValidator<DepartmentAddDto>
    {
        public DepartmentAddValidator()
        {

            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");

        }
    }
}
