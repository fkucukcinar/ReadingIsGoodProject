using BookStore.Api.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Validators
{
    public class SaveCustomerValidator: AbstractValidator<CustomerDTO>
    {
        public SaveCustomerValidator()
        {
            RuleFor(a => a.Name)
             .NotEmpty()
             .MaximumLength(100);

            RuleFor(a => a.Address)
             .NotEmpty()
             .MaximumLength(200);

            RuleFor(a => a.Email)
             .NotEmpty()
             .MaximumLength(100);

            RuleFor(a => a.BirthDate)
             .NotEmpty();

            RuleFor(a => a.PhoneNumber)
             .NotEmpty()
             .MaximumLength(50);
        }
    }
}
