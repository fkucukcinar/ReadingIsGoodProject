using BookStore.Api.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Validators
{
    public class SaveOrderValidator : AbstractValidator<OrderDTO>
    {
        public SaveOrderValidator()
        {
            RuleFor(a => a.CustomerId)
             .NotEmpty();
             
            RuleFor(a => a.StatusId)
             .NotEmpty();

            RuleFor(a => a.CreateDate)
             .NotEmpty();
        }
    }
}
