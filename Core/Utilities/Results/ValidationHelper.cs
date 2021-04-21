using Core.Extensions;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Utilities.Business
{
    public static class ValidationHelper
    {
        public static IList<ValidationError> GetErrors(IList<ValidationFailure> errors, string TypeName = null)
        {
            IList<ValidationError> errorList = new List<ValidationError>();
            foreach (var error in errors)
            {
                errorList.Add(new ValidationError
                {
                    TypeName = TypeName,
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                });
            }
            return errorList;
        }
    }
}
