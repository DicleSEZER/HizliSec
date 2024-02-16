﻿using FluentValidation;
using HizliSec.Entities.Concrete;

namespace HizliSec.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CreateDate).NotNull();
        }
    }
}
