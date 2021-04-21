using Entities.Concrate;
using Entities.Constants;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.ValidationRules
{
  public  class CurrencyValidator : AbstractValidator<CurrencyDto>
    {
        public CurrencyValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Para birimi adı alanı boş geçilemez.");
            RuleFor(m => m.Code).NotEmpty().WithMessage("Para kodu alanı boç geçilemez.");
            RuleFor(m => m.OperationType).MaximumLength(3).WithMessage("Para kodu alanı 3 karakterden fazla olamaz.");
            RuleFor(m => m.OperationType).Must(m => validOperationType(m)).WithMessage("Geçerli bir işlem türü seçin.");
        }
        private bool validOperationType(string value)
        {
            return CurrencyEnum.CurrencyTypeList().Any(m => m.Value == value);
        }
    }
}
